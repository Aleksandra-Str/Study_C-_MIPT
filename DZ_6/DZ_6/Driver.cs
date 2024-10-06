using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_6
{
    public abstract class Driver
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string LiscenseNumber { get; set; }
        public int ExperienceYears { get; set; }


        public abstract string GetDriver();// будет возвращать тип водителя
        public virtual void ShowDetails()
        {
            Console.WriteLine($"Водитель: {Name}");
            Console.WriteLine($"Возраст: {Age}");
            Console.WriteLine($"Номер лицензии: {LiscenseNumber}");
            Console.WriteLine($"Водительский стаж: {ExperienceYears}\n");
        }

        public abstract bool CanDrive(string typeCar);
    }


    public class Coachman : Driver
    {
        public Coachman(string name, int age, string liscenseNumber, int experienceYears) 
        { 
            Name = name;
            Age = age;
            LiscenseNumber = liscenseNumber;
            ExperienceYears = experienceYears;

        }

        public override string GetDriver() =>  "Кучер"; // лямбда выражение (то же самое, что ниже в теле метода
                                                        //{
                                                        // return "Кучер";
                                                        // }

        public override bool CanDrive(string typeCar)
        {
            return typeCar == "Гужевое такси";
        }
    }

    public class Trackman : Driver
    {
        public Trackman(string name, int age, string liscenseNumber, int experienceYears)
        {
            Name = name;
            Age = age;
            LiscenseNumber = liscenseNumber;
            ExperienceYears = experienceYears;

        }

        public override string GetDriver() => "Дальнобойщик"; // лямбда выражение (то же самое, что ниже в теле метода
                                                       //{
                                                       // return "Кучер";
                                                       // }

        public override bool CanDrive(string typeCar)
        {
            return typeCar == "Грузовое такси";
        }
    }
}
