using static DZ_8.TaxiMemento;
using static DZ_8.TaxiState;
using static DZ_8.TariffStrategy;

namespace DZ_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем такси с тарифом "Стандарт"
            Taxi taxi = new Taxi(new StandardTariff());
            Console.WriteLine($"Стоимость поездки 5 км: {taxi.GetFare(5)} руб.");

            // Сменим тариф на "Эконом"
            taxi.SetTariff(new EconomyTariff());
            Console.WriteLine($"Стоимость поездки 5 км: {taxi.GetFare(5)} руб.");

            // Работа с состояниями такси
            TaxiContext taxiContext = new TaxiContext();
            taxiContext.Start(); // Переключаемся в состояние "Движется"
            taxiContext.Stop();  // Переключаемся в состояние "Стоит"

            // Работа с сохранением и восстановлением состояния (Memento)
            TaxiWithMemento taxiWithMemento = new TaxiWithMemento
            {
                Driver = "Иванов И.И.",
                Mileage = 1000,
                Status = "Стоит"
            };

            // Сохраняем текущее состояние
            TaxiMemento savedState = taxiWithMemento.SaveState();

            // Изменяем состояние такси
            taxiWithMemento.Mileage = 1050;
            taxiWithMemento.Status = "Движется";
            Console.WriteLine($"Текущее состояние: {taxiWithMemento.Status}, Пробег: {taxiWithMemento.Mileage}");

            // Восстанавливаем сохраненное состояние
            taxiWithMemento.RestoreState(savedState);
            Console.WriteLine($"Восстановленное состояние: {taxiWithMemento.Status}, Пробег: {taxiWithMemento.Mileage}");
        }
    }
}
