using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_6
{
    public class Client
    {
        private Driver _driver;
        private Movement _movement;

        public Client(TaxiFactory factory, string driverName, int driverAge, string liscenseNumber, int experienceYears)// передаем taxifactory для работы клиента с ним
        {
            _driver = factory.CreateDriver(driverName, driverAge, liscenseNumber, experienceYears);
            _movement = factory.CreateMovement();
        }

        public void ProcessOrder()
        {
            Console.WriteLine($"Вашим такси управляет: {_driver.GetDriver()} и оно {_movement.GetMovement()}");
            _driver.ShowDetails();
            _movement.ShowDetails();

            if (_movement.IsEcoFriendly())
            { Console.WriteLine("Это такси экологично"); }
            else { Console.WriteLine("Это такси не экологично"); }

            Console.WriteLine($"Водитель может управлять грузовым такси: {_driver.CanDrive("Грузовое такси")}");
            Console.WriteLine($"Водитель может управлять гужевым такси: {_driver.CanDrive("Гужевое такси")}");
        }
    }
}
