using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Heroes
{
    public class Warrior : HeroBase
    {
        public Warrior() { }

        public Warrior(string name) : base(name) { }

        public override string GetInfo()
        {
            return $"Warrior: {Name}";
        }
    }
}
