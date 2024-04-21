using Decorator.Decorator;
using Decorator.Heroes;

var mage = new Mage("Vladyslava Vozniuk");

Console.WriteLine(mage.GetInfo());

HeroDecorator decoratedMage = new ArmorDecorator(mage);
decoratedMage = new ArtefactDecorator(decoratedMage);
decoratedMage = new ArtefactDecorator(decoratedMage);

Console.WriteLine("Decorated varsion: ");
Console.WriteLine(decoratedMage.GetInfo());

