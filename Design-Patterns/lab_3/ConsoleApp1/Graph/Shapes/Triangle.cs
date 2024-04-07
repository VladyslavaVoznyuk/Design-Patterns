using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Shapes
{
    public class Triangle : IShape
    {
        public int Side1 { get; set; }
        public int Side2 { get; set; }
        public int Side3 { get; set; }

        public Triangle(int side1 = 1, int side2 = 1, int side3 = 1)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        public object GetRenderInfo()
        {
            return $"Triangle with sides: {Side1}, {Side2}, {Side3}";
        }
    }
}
