using System.ComponentModel.Design;

namespace Study_C__MIPT
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Animal[] animals = new Animal[2] { new Cat(5), new Dog(6) };
            animals[0].SetName("Крыльчатка");
            animals[1].SetName("Этажерка");

            Console.WriteLine(animals[0].Name);
            Test(animals[0]);


            Console.WriteLine(animals[1].Name);
            Test(animals[1]);


        }


         static void Test(Animal pet)
          {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                pet.Feed(rnd.Next(1, 60));
                pet.Punish(rnd.Next(1, 20));
            }
            pet.ShowHealth();
          }

    }




}
