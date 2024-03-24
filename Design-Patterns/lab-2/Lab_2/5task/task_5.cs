using System;

public class Character
{
    public string Name { get; set; }
    public int Height { get; set; }
    public string Build { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public string Clothing { get; set; }
    public string Inventory { get; set; }

    public void Display()
    {
        Console.WriteLine($"Character: {Name}");
        Console.WriteLine($"Height: {Height} cm");
        Console.WriteLine($"Build: {Build}");
        Console.WriteLine($"Hair color: {HairColor}");
        Console.WriteLine($"Eye color: {EyeColor}");
        Console.WriteLine($"Clothing: {Clothing}");
        Console.WriteLine($"Inventory: {Inventory}");
        Console.WriteLine();
    }
}


public interface ICharacterBuilder
{
    ICharacterBuilder SetName(string name);
    ICharacterBuilder SetHeight(int height);
    ICharacterBuilder SetBuild(string build);
    ICharacterBuilder SetHairColor(string hairColor);
    ICharacterBuilder SetEyeColor(string eyeColor);
    ICharacterBuilder SetClothing(string clothing);
    ICharacterBuilder SetInventory(string inventory);
    Character Build();
}

public class HeroBuilder : ICharacterBuilder
{
    private Character character = new Character();

    public ICharacterBuilder SetName(string name)
    {
        character.Name = name;
        return this;
    }

    public ICharacterBuilder SetHeight(int height)
    {
        character.Height = height;
        return this;
    }

    public ICharacterBuilder SetBuild(string build)
    {
        character.Build = build;
        return this;
    }

    public ICharacterBuilder SetHairColor(string hairColor)
    {
        character.HairColor = hairColor;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string eyeColor)
    {
        character.EyeColor = eyeColor;
        return this;
    }

    public ICharacterBuilder SetClothing(string clothing)
    {
        character.Clothing = clothing;
        return this;
    }

    public ICharacterBuilder SetInventory(string inventory)
    {
        character.Inventory = inventory;
        return this;
    }

    public Character Build()
    {
        return character;
    }
}

public class CharacterDirector
{
    private ICharacterBuilder builder;

    public CharacterDirector(ICharacterBuilder builder)
    {
        this.builder = builder;
    }

    public Character BuildCharacter()
    {
        return builder.Build();
    }
}

class Program
{
    static void Main(string[] args)
    {
      
        HeroBuilder heroBuilder = new HeroBuilder();
        Character hero = heroBuilder
            .SetName("Hero")
            .SetHeight(180)
            .SetBuild("Athletic")
            .SetHairColor("Blonde")
            .SetEyeColor("Blue")
            .SetClothing("Armor")
            .SetInventory("Sword, Shield")
            .Build();
        hero.Display();
    }
}
