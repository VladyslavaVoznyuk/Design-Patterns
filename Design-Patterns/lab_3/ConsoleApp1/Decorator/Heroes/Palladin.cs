using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Heroes
{
    public class Palladin : HeroBase
    {
        public Palladin() { }

        public Palladin(string name) : base(name) { }

        public override string GetInfo()
        {
            return $"Palladin: {Name}";
        }
    }
}
