using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_C__MIPT
{
    
    
        

        class Car
        {
            class Engine
            {
                private int size;
                public Engine(int baseSize)
                {
                    size = baseSize;
                }
            }


            private int number;
            private Engine engine;

            static int idCount = 1;

            public Car(int baseSize = 1)
            {
                number = idCount++;
                engine = new Engine(baseSize);
            }

            public string GetInfo()
            {
            return number.ToString();
            }

        }


        class Customer
        {
            private Car car;
            public Car Car { get => car; set => car = value; } // value - подаваемое в set значение
            private string fio;

            public Customer(string baseFio) 
            { 
                fio = baseFio;

            }

            public string GetInfo ()
            {
                if (car != null)
                {
                    return fio + " " + car.GetInfo();
                }
                else 
                {
                    return fio + " нет машины";
                }
            }
        }

        class FactoryAF
        {
            private List<Car> cars;
            private List<Customer> customers;
            
            public FactoryAF () 
            {
                 cars = new List<Car> ();
                 customers = new List<Customer> ();

            }

            public void AddCar ()
            {
                cars.Add (new Car ()); // композиция. новую машину создаем внутри завода, и никто не сможет получить к ней доступ
            }

            public void AddCustomer (Customer newCustomer)// отправляем в метод уже существующего customer
            {
                customers.Add (newCustomer);
            }

            public void SaleCar()
            {
                foreach (Customer customer in customers)
                {
                    if (cars.Count == 0)
                    {
                        return;
                    }
                    if (customer.Car == null )
                    {
                        customer.Car = cars[cars.Count - 1];
                        cars.RemoveAt (cars.Count - 1);
                    }
                                       
                }

                cars.Clear ();

            }

            public void WriteInfo ()
            {
                 foreach(Customer customer in customers)
                 {
                   Console.WriteLine( customer.GetInfo ());
                 }

                 foreach (Car car in cars)
                 {
                    Console.WriteLine( car.GetInfo ());
                 }
            }

        }


    }

