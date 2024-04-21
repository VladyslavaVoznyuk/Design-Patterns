using System;
using System.Collections.Generic;

public abstract class Subscription
{
    public double MonthlyFee { get; protected set; }
    public int MinimumSubscriptionPeriod { get; protected set; }
    public List<string> Channels { get; protected set; }

    public Subscription(double monthlyFee, int minSubscriptionPeriod, List<string> channels)
    {
        MonthlyFee = monthlyFee;
        MinimumSubscriptionPeriod = minSubscriptionPeriod;
        Channels = channels;
    }
}

public class DomesticSubscription : Subscription
{
    public DomesticSubscription() : base(10.99, 1, new List<string> { "News", "Entertainment", "Sports" })
    {
    }
}

public class EducationalSubscription : Subscription
{
    public EducationalSubscription() : base(7.99, 3, new List<string> { "Documentary", "Educational", "Science" })
    {
    }
}

public class PremiumSubscription : Subscription
{
    public PremiumSubscription() : base(19.99, 6, new List<string> { "Movies", "TV Shows", "Premium Channels" })
    {
    }
}

public interface ISubscriptionFactory
{
    Subscription CreateSubscription();
}

public class WebSite : ISubscriptionFactory
{
    public Subscription CreateSubscription()
    {
        return new PremiumSubscription();
    }
}

public class MobileApp : ISubscriptionFactory
{
    public Subscription CreateSubscription()
    {
        return new DomesticSubscription();
    }
}

public class ManagerCall : ISubscriptionFactory
{
    public Subscription CreateSubscription()
    {
        return new EducationalSubscription();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ISubscriptionFactory webFactory = new WebSite();
        Subscription webSubscription = webFactory.CreateSubscription();
        Console.WriteLine("Web Subscription - Monthly Fee: $" + webSubscription.MonthlyFee +
            ", Minimum Subscription Period: " + webSubscription.MinimumSubscriptionPeriod + " months, Channels: " +
            string.Join(", ", webSubscription.Channels));

        ISubscriptionFactory mobileFactory = new MobileApp();
        Subscription mobileSubscription = mobileFactory.CreateSubscription();
        Console.WriteLine("Mobile Subscription - Monthly Fee: $" + mobileSubscription.MonthlyFee +
            ", Minimum Subscription Period: " + mobileSubscription.MinimumSubscriptionPeriod + " months, Channels: " +
            string.Join(", ", mobileSubscription.Channels));

        ISubscriptionFactory managerFactory = new ManagerCall();
        Subscription managerSubscription = managerFactory.CreateSubscription();
        Console.WriteLine("Manager Subscription - Monthly Fee: $" + managerSubscription.MonthlyFee +
            ", Minimum Subscription Period: " + managerSubscription.MinimumSubscriptionPeriod + " months, Channels: " +
            string.Join(", ", managerSubscription.Channels));
    }
}
