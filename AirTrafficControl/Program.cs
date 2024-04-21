using System;
using System.Collections.Generic;

namespace DesignPatterns.Mediator
{
 
    public class CommandCentre
    {
        private List<Runway> _runways;
        private List<Aircraft> _aircrafts;

        public CommandCentre()
        {
            _runways = new List<Runway>();
            _aircrafts = new List<Aircraft>();
        }

        public void AddRunway(Runway runway)
        {
            _runways.Add(runway);
        }

        public void AddAircraft(Aircraft aircraft)
        {
            _aircrafts.Add(aircraft);
        }

        public void RequestLanding(Aircraft aircraft)
        {
            foreach (var runway in _runways)
            {
                if (runway.IsAvailable())
                {
                    Console.WriteLine($"Aircraft {aircraft.Name} is landing.");
                    runway.Land();
                    return;
                }
            }
            Console.WriteLine($"Could not land {aircraft.Name}, all runways are busy.");
        }

        public void RequestTakeoff(Aircraft aircraft)
        {
            foreach (var runway in _runways)
            {
                if (runway.IsAvailable())
                {
                    Console.WriteLine($"Aircraft {aircraft.Name} is taking off.");
                    runway.TakeOff();
                    return;
                }
            }
            Console.WriteLine($"Could not take off {aircraft.Name}, all runways are busy.");
        }
    }

    public class Aircraft
    {
        public string Name { get; }

        public Aircraft(string name)
        {
            Name = name;
        }
    }

    public class Runway
    {
        public readonly Guid Id = Guid.NewGuid();
        public bool IsBusy { get; private set; }

        public bool IsAvailable()
        {
            return !IsBusy;
        }

        public void Land()
        {
            Console.WriteLine($"Runway {Id} is now busy.");
            IsBusy = true;
        }

        public void TakeOff()
        {
            Console.WriteLine($"Runway {Id} is now free.");
            IsBusy = false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CommandCentre commandCentre = new CommandCentre();
            Runway runway1 = new Runway();
            Runway runway2 = new Runway();
            commandCentre.AddRunway(runway1);
            commandCentre.AddRunway(runway2);

            Aircraft aircraft1 = new Aircraft("Plane 1");
            Aircraft aircraft2 = new Aircraft("Plane 2");

            commandCentre.RequestLanding(aircraft1);
            commandCentre.RequestTakeoff(aircraft2);
        }
    }
}
