using ShapesFactory.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesFactory.Creators
{
    public abstract class ShapeCreator
    {
        public abstract IShape CreateShape();
    }
}
