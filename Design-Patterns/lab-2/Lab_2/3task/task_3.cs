using System;

public class Authenticator
{
    private static volatile Authenticator instance;
    private static object syncRoot = new object();

   

    public static Authenticator GetInstance()
    {
        if (instance == null)
        {
            lock (syncRoot)
            {
                if (instance == null)
                {
                    instance = new Authenticator();
                }
            }
        }
        return instance;
    }

    public void AuthenticateUser(string username, string password)
    {
        
        if (username == "admin" && password == "admin123")
        {
            Console.WriteLine($"Користувач {username} успішно аутентифікований.");
        }
        else
        {
            Console.WriteLine($"Користувач {username} не може бути аутентифікований. Невірні облікові дані.");
        }
    }

    public bool IsUserAuthenticated(string username)
    {
        
        if (username == "admin")
        {
            Console.WriteLine($"Користувач {username} аутентифікований.");
            return true;
        }
        else
        {
            Console.WriteLine($"Користувач {username} не аутентифікований.");
            return false;
        }
    }
}

class task_3
{
    static void Main(string[] args)
    {
        Authenticator auth1 = Authenticator.GetInstance();
        Authenticator auth2 = Authenticator.GetInstance();

        if (auth1 == auth2)
        {
            Console.WriteLine("auth1 та auth2 вказують на один і той же екземпляр Authenticator.");
        }
        else
        {
            Console.WriteLine("auth1 та auth2 вказують на різні екземпляри Authenticator.");
        }

        auth1.AuthenticateUser("user1", "password1");
        auth2.IsUserAuthenticated("user2");
    }
}
