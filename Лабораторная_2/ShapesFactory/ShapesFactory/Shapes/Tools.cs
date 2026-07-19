using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ShapesFactory.Shapes
{
    public interface ITypeOfShape
    {
        bool ConfirmeType(string typeOfShape);
        void GetRandomPosition(Random random, Canvas canvas, ref double x, ref double y, double sizeOfKeyPart);
    }
    public class CircleType : ITypeOfShape
    {
        public bool ConfirmeType(string typeOfShape) => "circle" == typeOfShape;
        public void GetRandomPosition(Random random, Canvas canvas, ref double x, ref double y, double sizeOfKeyPart)
        {
            x = random.Next(0, (int)(canvas.ActualWidth - sizeOfKeyPart*2));
            y = random.Next(50, (int)(canvas.ActualHeight - sizeOfKeyPart * 2));
        }
    }
    public class SquareType : ITypeOfShape
    {
        public bool ConfirmeType(string typeOfShape) => "square" == typeOfShape;
        public void GetRandomPosition(Random random, Canvas canvas, ref double x, ref double y, double sizeOfKeyPart)
        {
            x = random.Next(0, (int)(canvas.ActualWidth - sizeOfKeyPart));
            y = random.Next(50, (int)(canvas.ActualHeight - sizeOfKeyPart));
        }
    }

    public class TriangleType : ITypeOfShape
    {
        public bool ConfirmeType(string typeOfShape) => "triangle" == typeOfShape;
        public void GetRandomPosition(Random random, Canvas canvas, ref double x, ref double y, double sizeOfKeyPart)
        {
            double radius = sizeOfKeyPart / Math.Sqrt(3);
            x = random.Next((int)(sizeOfKeyPart / 2), (int)(canvas.ActualWidth - sizeOfKeyPart / 2));
            y = random.Next(50 + (int)radius, (int)(canvas.ActualHeight - radius / 2));
        }
    }


    public static class Tools
    {
        private static Random _random = new Random();
        private static List<ITypeOfShape> _typesOfShapes = new List<ITypeOfShape> {new CircleType(), new SquareType(), new TriangleType()};

        public static void GetRandomPosition(Canvas canvas, ref double x, ref double y, string typeOfShape = null, double sizeOfKeyPart = 0)
        {

            foreach (var type in _typesOfShapes)
            {
                if (type.ConfirmeType(typeOfShape))
                {
                    type.GetRandomPosition(_random, canvas, ref x, ref y, sizeOfKeyPart);
                }
            }
        }

        public static void Clear(Canvas canvas)
        {
            if (canvas.Children.Count > 1)
            {
                var toRemove = canvas.Children.OfType<Shape>().ToList();

                foreach (var shape in toRemove)
                {
                    canvas.Children.Remove(shape);
                }
            }
        }
    }
}
