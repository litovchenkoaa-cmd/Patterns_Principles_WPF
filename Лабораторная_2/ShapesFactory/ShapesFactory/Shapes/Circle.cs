using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace ShapesFactory.Shapes
{
    public class Circle : IShape
    {
        private readonly Brush _color;
        private readonly double _radius;

        public Circle(Brush color, double radius)
        {
            _color = color;
            _radius = radius;
        }

        public void Draw(Canvas canvas)
        {
            var ellipse = new Ellipse
            {
                Fill = _color,
                Width = _radius * 2,
                Height = _radius * 2
            };
            ellipse.Stroke = Brushes.Black;
            ellipse.StrokeThickness = 1;
            double x = 0, y = 0;
            Tools.GetRandomPosition(canvas, ref x, ref y, "circle", _radius);

            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);

            canvas.Children.Add(ellipse);
            
        }
    }
}
