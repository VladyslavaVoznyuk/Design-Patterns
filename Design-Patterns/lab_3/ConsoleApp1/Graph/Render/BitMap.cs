using Graph.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Render
{
    public class Bitmap : Shape
    {
        public Bitmap() { }
        public Bitmap(IShape shape) : base(shape) { }

        public override void Render()
        {
            Console.WriteLine($"Rendering as bitmap: {shape?.GetRenderInfo()}");
        }
    }
}
