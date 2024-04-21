using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Shapes
{
    public class Rectangle : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width = 1, int height = 1)
        {
            Width = width;
            Height = height;
        }

        public object GetRenderInfo()
        {
            return $"Rectangle with width = {Width} and height = {Height}";
        }
    }
}
