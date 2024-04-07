using Graph.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Render
{
    public class Vector : Shape
    {
        public Vector() { }
        public Vector(IShape shape) : base(shape) { }

        public override void Render()
        {
            Console.WriteLine($"Render as vector image: {shape?.GetRenderInfo()}");
        }
    }
}
