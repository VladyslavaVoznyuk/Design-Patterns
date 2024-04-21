using Graph.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Render
{
    public abstract class Shape
    {
        protected IShape? shape;

        public Shape() { }

        public Shape(IShape shape)
        {
            this.shape = shape;
        }

        public abstract void Render();
    }
}
