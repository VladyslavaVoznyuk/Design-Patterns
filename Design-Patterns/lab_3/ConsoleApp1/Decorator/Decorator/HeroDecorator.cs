using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Heroes;

namespace Decorator.Decorator
{
    public abstract class HeroDecorator : IHero
    {
        private IHero _hero { get; set; }

        public HeroDecorator(IHero hero)
        {
            _hero = hero;
        }

        public virtual string GetInfo()
        {
            return _hero.GetInfo();
        }
    }
}
