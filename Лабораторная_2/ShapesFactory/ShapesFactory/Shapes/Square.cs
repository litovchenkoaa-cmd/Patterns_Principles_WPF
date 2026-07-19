using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShapesFactory.Shapes
{
    public class Square : IShape
    {
        private readonly Brush _color;
        private readonly double _side;

        public Square(Brush color, double side)
        {
            _color = color;
            _side = side;
        }

        public void Draw(Canvas canvas)
        {
            var rectangle = new Rectangle
            {
                Fill = _color,
                Width = _side,
                Height = _side
            };

            rectangle.Stroke = Brushes.Black;
            rectangle.StrokeThickness = 1;
            double x = 0, y = 0;
            Tools.GetRandomPosition(canvas, ref x , ref y, "square", _side);

            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);

            canvas.Children.Add(rectangle);
        }


    }
}
