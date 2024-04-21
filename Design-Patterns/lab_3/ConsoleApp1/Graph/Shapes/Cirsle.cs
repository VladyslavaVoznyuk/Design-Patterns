using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Shapes
{
    public class Circle : IShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }

        public Circle(int x = 0, int y = 0, int radius = 1)
        {
            X = x; Y = y; Radius = radius;
        }

        public object GetRenderInfo()
        {
            return $"Circle at point ({X}, {Y}) with radius = {Radius}";
        }
    }
}
