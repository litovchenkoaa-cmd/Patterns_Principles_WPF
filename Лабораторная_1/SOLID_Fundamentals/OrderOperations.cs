namespace SOLID_Fundamentals//ISP
{

    public interface IOrderOperations
    {
        void CreateOrder(Order order);//1
        void UpdateOrder(Order order);//1
        void DeleteOrder(int orderId);//1

    }
    public interface IFinancialOperations
    {
        void ProcessPayment(Order order);//2
        void ShipOrder(Order order);//2
        void GenerateInvoice(Order order);//2
        void ExportToExcel(string filePath);//2
    }
    public interface ICommunicationOperations
    {
        void SendNotification(Order order);//3
        void GenerateReport(DateTime from, DateTime to);//3
    }
    public interface IAdministrationOperations
    {
        void BackupDatabase();//4
        void RestoreDatabase();//4
    }

    public class OrderManager : IOrderOperations, IFinancialOperations, ICommunicationOperations, IAdministrationOperations
    {
        public void CreateOrder(Order order)
        {
            Console.WriteLine("Order created");
        }

        public void UpdateOrder(Order order)
        {
            Console.WriteLine("Order updated");
        }

        public void DeleteOrder(int orderId)
        {
            Console.WriteLine("Order deleted");
        }

        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Payment processed");
        }

        public void ShipOrder(Order order)
        {
            Console.WriteLine("Order shipped");
        }

        public void GenerateInvoice(Order order)
        {
            Console.WriteLine("Invoice generated");
        }

        public void SendNotification(Order order)
        {
            Console.WriteLine("Notification sent");
        }

        public void GenerateReport(DateTime from, DateTime to)
        {
            Console.WriteLine("Report generated");
        }

        public void ExportToExcel(string filePath)
        {
            Console.WriteLine("Exported to Excel");
        }

        public void BackupDatabase()
        {
            Console.WriteLine("Database backed up");
        }

        public void RestoreDatabase()
        {
            Console.WriteLine("Database restored");
        }
    }

    public class CustomerPortal : IOrderOperations
    {
        public void CreateOrder(Order order)
        {
            Console.WriteLine("Order created by customer");
        }

        public void UpdateOrder(Order order)
        {
            Console.WriteLine("Order updated by customer");
        }

        public void DeleteOrder(int orderId)
        {
            Console.WriteLine("Order deleted by customer");
        }

    }
}
