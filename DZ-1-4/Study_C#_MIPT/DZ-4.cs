using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Study_C__MIPT
{
    class Animal : IAlive
    {
        public int Health //определение метода из интерфейса
        { 
            get => health; 
            set 
            {
                health = value;
                
                OnHealthChanged(); //при изменении 
                
            } 
        } 
        private int health;

        public Animal(int health)
        {
            Health = health;
        }

        private void OnHealthChanged () 
        {
            if (Health < 0 && FeedMe != null) 
            { 
                FeedMe(this); // происходит событие
            }
        }
        public delegate void Feed(Animal? animal); //объявление делегата 
        public event Feed? FeedMe;//создали событие, FeedMe - название события, внутри события - создается делегат


    }
    class Herbo : Animal
    {
        private int goodness;

        public Herbo (int health, int goodness) : base (health)
        {

            this.goodness = goodness;
        }
    }
    class Predator : Animal
    {
        private string foodType;

        public Predator (int health, string foodType) : base(health)
        {
            this.foodType = foodType;
        }
    }
    class Monkey : Herbo
    {
        public Monkey (int health, int goodness) : base(health, goodness)
        {

        }
    }
    class Rabbit : Herbo
    {
        public Rabbit(int health, int goodness) : base(health, goodness)
        {

        }
    }
    class Tiger : Predator
    {
        public Tiger (int health, string foodType) : base (health, foodType)
        {

        }
    }
    class Wolf : Predator
    {
        public Wolf (int health, string foodType) : base(health, foodType)
        {

        }
    }
    class Manager
    {
        public Manager(Vetclinic vetclinic)
        {
            vetclinic.AnimalsInZoo.CollectionChanged  += ColectionChangedEventHandler;
        }

        private void ColectionChangedEventHandler(object? sender, NotifyCollectionChangedEventArgs args)// обработчик события ColectionChanged
        {
            switch (args.Action) 
            {
                case NotifyCollectionChangedAction.Add:
                    if (args.NewItems != null)
                    {
                        foreach (Animal? animal in args.NewItems)
                        {
                            if (animal != null)
                            {
                                animal.FeedMe += FeedMeHandler; //добавление в событие (FeedMe) обработчика FeedMeHandler. а событие внутри себя положило этот обработчик в делегат Feed
                            }
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    if (args.OldItems != null)
                    {
                        foreach (Animal? animal in args.OldItems)
                        {
                            if (animal != null)
                            {
                                animal.FeedMe -= FeedMeHandler; //удаление из события (FeedMe) обработчика FeedMeHandler. а событие внутри себя удалила этот обработчик из делегата Feed
                            }
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Replace: // при изменении одного животного на другое
                    if (args.NewItems != null)
                    {
                        foreach (Animal? animal in args.NewItems)
                        {
                            if (animal != null)
                            {
                                animal.FeedMe += FeedMeHandler; //добавление в событие (FeedMe) обработчика FeedMeHandler. а событие внутри себя положило этот обработчик в делегат Feed
                            }
                        }
                    }
                    if (args.OldItems != null)
                    {
                        foreach (Animal? animal in args.OldItems)
                        {
                            if (animal != null)
                            {
                                animal.FeedMe -= FeedMeHandler; //удаление из события (FeedMe) обработчика FeedMeHandler. а событие внутри себя удалила этот обработчик из делегата Feed
                            }
                        }
                    }

                    break;


            }
            
        }

        public void FeedMeHandler(Animal? animal)
        {
            if (animal != null) 
            {
                Console.WriteLine("monkey " + animal.Health);
                animal.Health += 1;
                
            }
        }
    }
    class Thing : IInventory
    {
       public int Number { get; set; }
    }
    class Table : Thing
    {

    }
    class Computer : Thing
    {

    }

    class Vetclinic
    {
        public ObservableCollection<Animal> AnimalsInZoo => animalsInZoo;

        private ObservableCollection<Animal> animalsInZoo;

        public Vetclinic()
        {
            animalsInZoo = new ObservableCollection<Animal>();
        }

        public void AddAnimal (Animal animal)
        {
            animalsInZoo.Add(animal);
            
        }

        public void RemoveAnimal (Animal animal)
        {
            animalsInZoo.Remove(animal);
        }

    }















    interface IAlive
    {
        int Health { get; set; }

    }
    interface IInventory
    {
        int Number { get; set; }
    }




}
