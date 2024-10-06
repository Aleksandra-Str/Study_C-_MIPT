using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DZ_6
{
    public abstract class Movement
    {
        public int Speed { get; set; }
        public string Terrain { get; set; }
        public int FuelConsumption { get; set; }


        public abstract string GetMovement();

        public virtual void ShowDetails()
        {
            Console.WriteLine($"Скорость: {Speed}");
            Console.WriteLine($"Местность: {Terrain}");
            Console.WriteLine($"Раход топлива: {FuelConsumption}\n");
            
        }

        public virtual bool IsEcoFriendly() 
        { 
            return FuelConsumption < 10;
        }
    }


    public class Gallop : Movement
    {
        public Gallop() 
        {
            Speed = 15;
            Terrain = "Поле";
            FuelConsumption = 5;

        }

        public override string GetMovement() => "Скачет";
                  
    }

    public class Drag : Movement
    {
        public Drag()
        {
            Speed = 30;
            Terrain = "Асфальт";
            FuelConsumption = 20;

        }

        public override string GetMovement() => "Тащится";

    }
}
