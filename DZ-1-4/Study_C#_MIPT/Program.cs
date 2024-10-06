using System.ComponentModel.Design;
using System.Runtime.Serialization.Formatters;

namespace Study_C__MIPT
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //Monkey[] monkeys = new Monkey[12];
            
            int a = 10;

            // Console.WriteLine(a);

            //for (int i = 0; i < monkeys.Length; i++)
            //{
            //    monkeys[i] = new Monkey(i, i - 3);
            //}

            
            Vetclinic vetclinic = new Vetclinic();
            Manager manager = new Manager(vetclinic);

            //foreach (Monkey monkey in monkeys)
            //{
            //    vetclinic.AddAnimal(monkey);
            //}


            Monkey monkey = new Monkey(1, 6);

            vetclinic.AddAnimal(monkey);

            monkey.Health = -5;
            Console.WriteLine("monkey 7 = " + monkey.Health);
            vetclinic.RemoveAnimal(monkey);

            monkey.Health = -3;


            Console.WriteLine("monkey 7 = " + monkey.Health);
                

            // Console.WriteLine(monkeys[0].Health);



            //Animal[] animals = new Animal[2] { new Cat(5), new Dog(6) };
            //animals[0].SetName("Крыльчатка");
            //animals[1].SetName("Этажерка");

            //Console.WriteLine(animals[0].Name);
            //Test(animals[0]);


            //Console.WriteLine(animals[1].Name);
            //Test(animals[1]);

            //FactoryAF factoryAF = new FactoryAF();

            //for (int i = 0; i < 10; i++)
            //{
            //    factoryAF.AddCar();

            //}


            //for (int i = 0; i < 9; i++)
            //{                
            //    factoryAF.AddCustomer(new Customer(i.ToString()));
            //}


            //factoryAF.WriteInfo();

            //factoryAF.SaleCar();

            //Console.WriteLine();

            //factoryAF.WriteInfo();







        }


         //static void Test(Animal pet)
         // {
         //   Random rnd = new Random();
         //   for (int i = 0; i < 10; i++)
         //   {
         //       pet.Feed(rnd.Next(1, 60));
         //       pet.Punish(rnd.Next(1, 20));
         //   }
         //   pet.ShowHealth();
         // }

    }




}
