using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_7
{
    // Абстрактный базовый компонент для пиццы
    public abstract class PizzaComponent
    {
        // Метод для получения описания пиццы
        public abstract string GetDescription();

        // Метод для получения стоимости пиццы
        public abstract double GetCost();
    }

    // Конкретная реализация базовой пиццы
    public class BasicPizza : PizzaComponent
    {
        // Возвращаем описание базовой пиццы
        public override string GetDescription() => "Базовая пицца";

        // Возвращаем стоимость базовой пиццы
        public override double GetCost() => 200; // Цена базовой пиццы
    }

    // Абстрактный декоратор для добавления ингредиентов
    public abstract class PizzaDecorator : PizzaComponent
    {
        // Ссылка на декорируемую пиццу
        protected PizzaComponent _pizza;

        // Конструктор принимает объект пиццы для декорирования
        public PizzaDecorator(PizzaComponent pizza) => _pizza = pizza;
    }

    // Конкретный декоратор для добавления сыра
    public class CheeseDecorator : PizzaDecorator
    {
        // Конструктор принимает пиццу и добавляет сыр
        public CheeseDecorator(PizzaComponent pizza) : base(pizza) { }

        // Добавляем описание сыра к существующему описанию
        public override string GetDescription() => _pizza.GetDescription() + ", сыр";

        // Увеличиваем стоимость пиццы на цену сыра
        public override double GetCost() => _pizza.GetCost() + 50;
    }

    // Конкретный декоратор для добавления пепперони
    public class PepperoniDecorator : PizzaDecorator
    {
        // Конструктор принимает пиццу и добавляет пепперони
        public PepperoniDecorator(PizzaComponent pizza) : base(pizza) { }

        // Добавляем описание пепперони к существующему описанию
        public override string GetDescription() => _pizza.GetDescription() + ", пепперони";

        // Увеличиваем стоимость пиццы на цену пепперони
        public override double GetCost() => _pizza.GetCost() + 70;
    }

}
