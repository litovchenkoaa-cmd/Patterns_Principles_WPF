using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID_Fundamentals//SRP
{
    // --- ИНТЕРФЕЙСЫ (Абстракции) ---

    public interface IPaymentService
    {
        void Process(string paymentMethod, decimal amount);
    }

    public interface IInventoryService
    {
        void Update(List<string> items);
    }

    public interface IOrderLogger
    {
        void Log(string message);
    }

    public interface IReportingService
    {
        void GenerateReceipt(Order order);
        void ExportToExcel(string filePath);
        void GenerateMonthlyReport(List<Order> orders);
    }

    // --- РЕАЛИЗАЦИИ (Детали) ---

    public class PaymentService : IPaymentService
    {
        public void Process(string paymentMethod, decimal amount)
        {
            Console.WriteLine($"Payment processed: {amount} via {paymentMethod}");
        }
    }

    public class InventoryService : IInventoryService
    {
        public void Update(List<string> items)
        {
            Console.WriteLine($"Inventory updated for {items.Count} items");
        }
    }

    public class OrderLogger : IOrderLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }
    }

    public class ReportingService : IReportingService
    {
        public void GenerateReceipt(Order order)
        {
            Console.WriteLine($"Receipt generated for Order #{order.Id}");
        }

        public void ExportToExcel(string filePath)
        {
            Console.WriteLine($"Exporting orders to {filePath}");
        }

        public void GenerateMonthlyReport(List<Order> orders)
        {
            decimal totalRevenue = orders.Sum(o => o.TotalAmount);
            int totalOrders = orders.Count;
            Console.WriteLine($"Monthly Report: {totalOrders} orders, Revenue: {totalRevenue:C}");
        }
    }

    // --- ОСНОВНОЙ КЛАСС (Оркестратор) ---

    public class OrderProcessor
    {
        private readonly List<Order> _orders = new List<Order>();
        private readonly IEmailService _emailService; // Из файла Services.cs
        private readonly IPaymentService _paymentService;
        private readonly IInventoryService _inventoryService;
        private readonly IOrderLogger _orderLogger;
        private readonly IReportingService _reportingService;

        public OrderProcessor(
            IEmailService emailService,
            IPaymentService paymentService,
            IInventoryService inventoryService,
            IOrderLogger orderLogger,
            IReportingService reportingService)
        {
            _emailService = emailService;
            _paymentService = paymentService;
            _inventoryService = inventoryService;
            _orderLogger = orderLogger;
            _reportingService = reportingService;
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
            Console.WriteLine($"Order {order.Id} added to list");
        }

        public void ProcessOrder(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                Console.WriteLine($"Processing order {orderId}");

                if (order.TotalAmount <= 0)
                    throw new ArgumentException("Invalid order amount"); // Лучше ArgumentException для валидации

                // Делегирование ответственности (SRP + DIP)
                _paymentService.Process(order.PaymentMethod, order.TotalAmount);
                _inventoryService.Update(order.Items);
                _emailService.SendEmail(order.CustomerEmail, $"Order {orderId} processed", "Your order is being processed.");
                _orderLogger.Log($"Order {orderId} processed at {DateTime.Now}");
                _reportingService.GenerateReceipt(order);
            }
            else
            {
                Console.WriteLine($"Order {orderId} not found");
            }
        }

        // Методы отчетов также делегированы, OrderProcessor больше не занимается Excel и MonthlyReport напрямую
        public void ExportData(string filePath) => _reportingService.ExportToExcel(filePath);
        public void ShowMonthlyReport() => _reportingService.GenerateMonthlyReport(_orders);
    }
}