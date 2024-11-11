using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    interface TariffStrategy
    {
        // Интерфейс для паттерна Стратегия, который определяет метод для расчета тарифа
        public interface ITariffStrategy
        {
            // Метод для расчета стоимости поездки
            double CalculateFare(double distance);
        }

        // Реализация тарифа "Стандарт"
        public class StandardTariff : ITariffStrategy
        {
            public double CalculateFare(double distance)
            {
                // Расчет стоимости для стандартного тарифа
                return distance * 10; // 10 рублей за км
            }
        }

        // Реализация тарифа "Эконом"
        public class EconomyTariff : ITariffStrategy
        {
            public double CalculateFare(double distance)
            {
                // Расчет стоимости для эконом тарифа
                return distance * 8; // 8 рублей за км
            }
        }

        // Класс Taxi, который использует стратегию для расчета тарифа
        public class Taxi
        {
            private ITariffStrategy _tariffStrategy;

            public Taxi(ITariffStrategy tariffStrategy)
            {
                _tariffStrategy = tariffStrategy;
            }

            // Метод для смены тарифа
            public void SetTariff(ITariffStrategy tariffStrategy)
            {
                _tariffStrategy = tariffStrategy;
            }

            // Метод для получения стоимости поездки
            public double GetFare(double distance)
            {
                return _tariffStrategy.CalculateFare(distance);
            }
        }


    }
}
