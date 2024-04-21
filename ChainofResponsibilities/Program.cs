using System;

abstract class SupportHandler
{
    protected SupportHandler successor;

    public void SetSuccessor(SupportHandler successor)
    {
        this.successor = successor;
    }

    public abstract bool HandleRequest(int level);
}
class Level1Handler : SupportHandler
{
    public override bool HandleRequest(int level)
    {
        if (level == 1)
        {
            Console.WriteLine("Ви звернулися до рівня підтримки 1. Як ми можемо допомогти вам?");
            return true;
        }
        else if (successor != null)
        {
            return successor.HandleRequest(level);
        }
        return false;
    }
}

class Level2Handler : SupportHandler
{
    public override bool HandleRequest(int level)
    {
        if (level == 2)
        {
            Console.WriteLine("Ви звернулися до рівня підтримки 2. Як ми можемо допомогти вам?");
            return true;
        }
        else if (successor != null)
        {
            return successor.HandleRequest(level);
        }
        return false;
    }
}

class Level3Handler : SupportHandler
{
    public override bool HandleRequest(int level)
    {
        if (level == 3)
        {
            Console.WriteLine("Ви звернулися до рівня підтримки 3. Як ми можемо допомогти вам?");
            return true;
        }
        else if (successor != null)
        {
            return successor.HandleRequest(level);
        }
        return false;
    }
}

class Level4Handler : SupportHandler
{
    public override bool HandleRequest(int level)
    {
        if (level == 4)
        {
            Console.WriteLine("Ви звернулися до рівня підтримки 4. Як ми можемо допомогти вам?");
            return true;
        }
        else if (successor != null)
        {
            return successor.HandleRequest(level);
        }
        return false;
    }
}

class SupportSystem
{
    private SupportHandler handlerChain;

    public SupportSystem()
    {
        handlerChain = new Level1Handler();
        SupportHandler handler2 = new Level2Handler();
        SupportHandler handler3 = new Level3Handler();
        SupportHandler handler4 = new Level4Handler();

        handlerChain.SetSuccessor(handler2);
        handler2.SetSuccessor(handler3);
        handler3.SetSuccessor(handler4);
    }

    public void HandleRequest()
    {
        int level;
        do
        {
            Console.Write("Оберіть рівень підтримки (1-4): ");
        } while (!int.TryParse(Console.ReadLine(), out level) || level < 1 || level > 4);

        if (!handlerChain.HandleRequest(level))
        {
            Console.WriteLine("На жаль, немає доступного рівня підтримки для вашого вибору.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SupportSystem supportSystem = new SupportSystem();
        string choice;
        do
        {
            supportSystem.HandleRequest();
            Console.Write("Бажаєте звернутися до підтримки ще раз? (Так/Ні): ");
            choice = Console.ReadLine();
        } while (choice.ToLower() == "так");
    }
}
