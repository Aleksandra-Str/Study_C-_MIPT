using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_7
{
    // Абстрактный класс "Пицца"
    public abstract class Pizza
    {
        // Имя пиццы
        public string Name { get; set; }

        // Абстрактный метод для подготовки пиццы (будет переопределен в подклассах)
        public abstract void Prepare();

        // Метод для выпекания пиццы
        public void Bake() => Console.WriteLine("Выпекаем пиццу...");

        // Метод для нарезки пиццы
        public void Cut() => Console.WriteLine("Режем пиццу...");

        // Метод для упаковки пиццы
        public void Box() => Console.WriteLine("Упаковываем пиццу...");
    }

    // Класс конкретной пиццы "4 сыра"
    public class CheesePizza : Pizza
    {
        // Конструктор устанавливает имя пиццы
        public CheesePizza() => Name = "4 сыра";

        // Реализация метода подготовки пиццы
        public override void Prepare() => Console.WriteLine("Добавляем сыры...");
    }

    // Класс конкретной пиццы "Пепперони"
    public class PepperoniPizza : Pizza
    {
        // Конструктор устанавливает имя пиццы
        public PepperoniPizza() => Name = "Пепперони";

        // Реализация метода подготовки пиццы
        public override void Prepare() => Console.WriteLine("Добавляем пепперони...");
    }

    // Абстрактный класс фабричного метода для создания пицц. В нем есть метод OrderPizza, и он отвечает за процесс создания пиццы
    public abstract class PizzaStore
    {
        // Метод для заказа пиццы
        public Pizza OrderPizza(string type)
        {
            // Создаем пиццу с помощью фабричного метода
            Pizza pizza = CreatePizza(type);

            // Подготавливаем, выпекаем, режем и упаковываем пиццу
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            // Возвращаем готовую пиццу
            return pizza;
        }

        // Абстрактный метод фабрики для создания конкретных типов пицц
        // protected - только внутри класса или наследников, для того что бы пицаа создавалась только
        // через OrderPizza
        protected abstract Pizza CreatePizza(string type);
    }

    // Конкретный класс фабрики для создания пицц
    public class SimplePizzaStore : PizzaStore
    {
        // Реализация фабричного метода для создания пицц на основе типа
        protected override Pizza CreatePizza(string type)
        {
            return type switch
            {
                "cheese" => new CheesePizza(),    // Создаем пиццу 4 сыра
                "pepperoni" => new PepperoniPizza(),  // Создаем пиццу Пепперони
                _ => throw new Exception("Неизвестный тип пиццы")  // Обработка неизвестного типа пиццы
            };
        }
    }

}
