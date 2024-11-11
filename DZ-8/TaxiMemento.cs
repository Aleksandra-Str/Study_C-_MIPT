using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    public class TaxiMemento
    {
        // Класс для хранения состояния такси (паттерн Хранитель)

        public string Driver { get; private set; }
        public double Mileage { get; private set; }
        public string Status { get; private set; }

        public TaxiMemento(string driver, double mileage, string status)
        {
            Driver = driver;
            Mileage = mileage;
            Status = status;
        }
    }

    // Класс Taxi, который может сохранять и восстанавливать свое состояние
    public class TaxiWithMemento
    {
        public string Driver { get; set; }
        public double Mileage { get; set; }
        public string Status { get; set; }

        // Создает сохранение состояния
        public TaxiMemento SaveState()
        {
            return new TaxiMemento(Driver, Mileage, Status);
        }

        // Восстанавливает сохраненное состояние
        public void RestoreState(TaxiMemento memento)
        {
            Driver = memento.Driver;
            Mileage = memento.Mileage;
            Status = memento.Status;
        }
    }

}

