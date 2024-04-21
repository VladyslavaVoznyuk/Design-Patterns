using System;
using System.Collections.Generic;

public class Virus : ICloneable
{
    public int Weight { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<Virus> Children { get; set; }

    public Virus(int weight, int age, string name, string type)
    {
        Weight = weight;
        Age = age;
        Name = name;
        Type = type;
        Children = new List<Virus>();
    }

    public object Clone()
    {
        Virus clone = new Virus(Weight, Age, Name, Type);
        foreach (var child in Children)
        {
            clone.Children.Add((Virus)child.Clone());
        }
        return clone;
    }
}

class task_4
{
    static void Main(string[] args)
    {
        
        Virus firstGenerationVirus = new Virus(10, 1, "Virus1", "Type1");
        Virus secondGenerationVirus1 = new Virus(8, 2, "Virus2", "Type2");
        Virus secondGenerationVirus2 = new Virus(9, 2, "Virus3", "Type3");
        Virus thirdGenerationVirus1 = new Virus(5, 3, "Virus4", "Type4");
        Virus thirdGenerationVirus2 = new Virus(7, 3, "Virus5", "Type5");

        firstGenerationVirus.Children.Add(secondGenerationVirus1);
        firstGenerationVirus.Children.Add(secondGenerationVirus2);
        secondGenerationVirus1.Children.Add(thirdGenerationVirus1);
        secondGenerationVirus1.Children.Add(thirdGenerationVirus2);

        Virus clonedVirus = (Virus)firstGenerationVirus.Clone();

        Console.WriteLine("Вірус-батько та його клон з дітьми:");
        PrintVirus(firstGenerationVirus);
        Console.WriteLine();
        PrintVirus(clonedVirus);
    }

    static void PrintVirus(Virus virus)
    {
        Console.WriteLine($"Name: {virus.Name}, Weight: {virus.Weight}, Age: {virus.Age}, Type: {virus.Type}");
        Console.WriteLine("Children:");
        foreach (var child in virus.Children)
        {
            PrintVirus(child);
        }
    }
}

