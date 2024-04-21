using System;
namespace ClassLibrary1
{
    
        public interface IDeviceFactory
        {
            Laptop CreateLaptop();
            Netbook CreateNetbook();
            EBook CreateEBook();
            Smartphone CreateSmartphone();
        }

        public class Laptop
        {
            public string Brand { get; set; }
            public Laptop(string brand)
            {
                Brand = brand;
            }
        }

        public class Netbook
        {
            public string Brand { get; set; }
            public Netbook(string brand)
            {
                Brand = brand;
            }
        }

        public class EBook
        {
            public string Brand { get; set; }
            public EBook(string brand)
            {
                Brand = brand;
            }
        }

        public class Smartphone
        {
            public string Brand { get; set; }
            public Smartphone(string brand)
            {
                Brand = brand;
            }
        }

        public class IPhoneFactory : IDeviceFactory
        {
            public Laptop CreateLaptop()
            {
                return new Laptop("IPhone");
            }

            public Netbook CreateNetbook()
            {
                return new Netbook("IPhone");
            }

            public EBook CreateEBook()
            {
                return new EBook("IPhone");
            }

            public Smartphone CreateSmartphone()
            {
                return new Smartphone("IPhone");
            }
        }

        public class XiaomiFactory : IDeviceFactory
        {
            public Laptop CreateLaptop()
            {
                return new Laptop("Xiaomi");
            }

            public Netbook CreateNetbook()
            {
                return new Netbook("Xiaomi");
            }

            public EBook CreateEBook()
            {
                return new EBook("Xiaomi");
            }

            public Smartphone CreateSmartphone()
            {
                return new Smartphone("Xiaomi");
            }
        }

        public class GalaxyFactory : IDeviceFactory
        {
            public Laptop CreateLaptop()
            {
                return new Laptop("Galaxy");
            }

            public Netbook CreateNetbook()
            {
                return new Netbook("Galaxy");
            }

            public EBook CreateEBook()
            {
                return new EBook("Galaxy");
            }

            public Smartphone CreateSmartphone()
            {
                return new Smartphone("Galaxy");
            }
        }

        class task_2
        {
            static void Main(string[] args)
            {
                IDeviceFactory factory;

               
                string brand = "IProne"; // можна змінити
                switch (brand)
                {
                    case "IProne":
                        factory = new IPhoneFactory();
                        break;
                    case "Kiaomi":
                        factory = new XiaomiFactory();
                        break;
                    case "Balaxy":
                        factory = new GalaxyFactory();
                        break;
                    default:
                        throw new ArgumentException("Unknown brand");
                }
                Laptop laptop = factory.CreateLaptop();
                Netbook netbook = factory.CreateNetbook();
                EBook ebook = factory.CreateEBook();
                Smartphone smartphone = factory.CreateSmartphone();

                // Перевірка правильності створених пристроїв
                Console.WriteLine("Laptop Brand: " + laptop.Brand);
                Console.WriteLine("Netbook Brand: " + netbook.Brand);
                Console.WriteLine("EBook Brand: " + ebook.Brand);
                Console.WriteLine("Smartphone Brand: " + smartphone.Brand);
            }
        }

    }
