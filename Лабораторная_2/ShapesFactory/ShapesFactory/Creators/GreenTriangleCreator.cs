using ShapesFactory.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ShapesFactory.Creators
{
    public class GreenTriangleCreator : ShapeCreator
    {
        public override IShape CreateShape()
        {
            var shape = new Triangle(Brushes.Green, 25);
            return shape;
        }
    }
}
