using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShapesFactory.Shapes
{
    public class Triangle : IShape
    {
        private readonly Brush _color;
        private readonly double _side;

        public Triangle(Brush color, double side)
        {
            _color = color;
            _side = side;
        }

        public void Draw(Canvas canvas)
        {
            var polygon = new Polygon();
            polygon.Fill = _color;
            polygon.Stroke = Brushes.Black;
            polygon.StrokeThickness = 1;
            
            double centerX = 0, centerY = 0, radius = _side / Math.Sqrt(3);
            Tools.GetRandomPosition(canvas, ref centerX, ref centerY, "triangle", _side);


            // Три вершины равностороннего треугольника
            // Углы: -90° (верх), 30° (правый низ), 150° (левый низ)
            var points = new PointCollection();

            for (int i = 0; i < 3; i++)
            {
                // -90° + i * 120°  →  равномерно распределяем вершины
                double angleInDegrees = -90 + i * 120;
                double angleInRadians = angleInDegrees * Math.PI / 180.0;

                double x = centerX + radius * Math.Cos(angleInRadians);
                double y = centerY + radius * Math.Sin(angleInRadians);

                points.Add(new System.Windows.Point(x, y));
            }

            polygon.Points = points;
            canvas.Children.Add(polygon);
        }
    }
}
