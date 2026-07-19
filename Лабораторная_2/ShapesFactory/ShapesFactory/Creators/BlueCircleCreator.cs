using ShapesFactory.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ShapesFactory.Creators
{
    public class BlueCircleCreator : ShapeCreator
    {
        public override IShape CreateShape()
        {
            var shape = new Circle(Brushes.Blue, 12.5);
            return shape;
        }
    }
}
