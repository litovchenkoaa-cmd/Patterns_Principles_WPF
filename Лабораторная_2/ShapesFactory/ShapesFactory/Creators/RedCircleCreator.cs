using ShapesFactory.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ShapesFactory.Creators
{
    public class RedCircleCreator : ShapeCreator
    {
        public override IShape CreateShape()
        {
            var shape = new Circle(Brushes.Red, 12.5);
            return shape;
        }
    }
}
