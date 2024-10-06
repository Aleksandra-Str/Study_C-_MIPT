using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_C__MIPT
{

   abstract class OldAnimal
    {
        
        public string Name { get; private set; } = string.Empty; // свойство
        public int Age { get; private set; } // свойство

        private int health; //поле

        public OldAnimal(int age)
        {
            Age = age;
            health = 90;

        }
        // Этот метод для кормления, при его вызове необходимо увеличивать
        // здоровье кошки(поле health) на foodCount единиц
        public void Feed(int foodCount)
        {
            health += foodCount;

        }

        public void Punish(int punchCount)
        {
            health -= punchCount;
        }

        public virtual void Say()
        {
            Console.WriteLine($"Name: {Name}\nAge: {Age}\n");

        }



        public void SetName(string newName)
        {
            if (Name == string.Empty)
            {
                Name = newName;

            }
         }

        public void ShowHealth()
        {
            if (health <= 50)
            {
                Console.WriteLine("белый");

            }
            if (health >= 51)
            {
                Console.WriteLine("зеленый");

            }
        }

    }


    class Cat : OldAnimal 
    {
        public Cat(int age):base(age)
        {
          

        }
        public override void Say() // перегрузка, дополняет старый метод еще каким нибудь методом
        {
          base.Say();
            Console.WriteLine("Мяу");

        }


    }

    class Dog : OldAnimal
    {
        public Dog(int age) : base(age)
        {


        }
        public override void Say()
        {
            base.Say();
            Console.WriteLine("Гав");

        }


    }

}

