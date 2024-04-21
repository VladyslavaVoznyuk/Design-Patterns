using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Heroes
{
    public class Mage : HeroBase
    {
        public Mage() { }

        public Mage(string name) : base(name) { }

        public override string GetInfo()
        {
            return $"Mage: {Name}";
        }
    }
}
