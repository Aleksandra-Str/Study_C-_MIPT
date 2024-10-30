namespace DZ_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Использование паттерна Factory Method
            PizzaStore store = new SimplePizzaStore();
            Pizza pizza = store.OrderPizza("cheese");  // Заказ пиццы 4 сыра
            Console.WriteLine($"Заказали пиццу: {pizza.Name}");

            // Использование паттерна Builder
            IDoughBuilder thinDoughBuilder = new ThinCrustDoughBuilder();  // Выбираем тонкое тесто
            PizzaChef chef = new PizzaChef(thinDoughBuilder);
            chef.MakeDough();
            PizzaDough dough = chef.GetDough();
            Console.WriteLine($"Выбрали тесто: {dough.DoughType}");

            // Использование паттерна Decorator
            PizzaComponent customPizza = new BasicPizza();  // Создаем базовую пиццу
            customPizza = new CheeseDecorator(customPizza);  // Добавляем сыр
            customPizza = new PepperoniDecorator(customPizza);  // Добавляем пепперони
            Console.WriteLine($"Пицца с составом: {customPizza.GetDescription()}");
            Console.WriteLine($"Итоговая стоимость: {customPizza.GetCost()} рублей");
        }
    }
}
