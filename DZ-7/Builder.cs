using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_7
{
    // Интерфейс для создания теста
    public interface IDoughBuilder
    {
        // Метод для установки типа теста
        void SetDoughType();

        // Метод для получения готового объекта теста
        PizzaDough GetDough();
    }

    // Класс теста для пиццы
    public class PizzaDough
    {
        // Тип теста
        public string DoughType { get; set; }
    }

    // Конкретный строитель для тонкого теста
    public class ThinCrustDoughBuilder : IDoughBuilder
    {
        // Внутренний объект теста
        private PizzaDough dough = new PizzaDough();

        // Устанавливаем тип теста как "тонкое"
        public void SetDoughType() => dough.DoughType = "Тонкое тесто";

        // Возвращаем объект теста
        public PizzaDough GetDough() => dough;
    }

    // Конкретный строитель для толстого теста
    public class ThickCrustDoughBuilder : IDoughBuilder
    {
        // Внутренний объект теста
        private PizzaDough dough = new PizzaDough();

        // Устанавливаем тип теста как "толстое"
        public void SetDoughType() => dough.DoughType = "Толстое тесто";

        // Возвращаем объект теста
        public PizzaDough GetDough() => dough;
    }

    // Класс Director, который управляет процессом создания теста
    public class PizzaChef
    {
        // Ссылка на строителя теста
        private IDoughBuilder doughBuilder;

        // Конструктор получает конкретного строителя
        public PizzaChef(IDoughBuilder builder) => doughBuilder = builder;

        // Запускаем процесс создания теста
        public void MakeDough() => doughBuilder.SetDoughType();

        // Возвращаем готовое тесто
        public PizzaDough GetDough() => doughBuilder.GetDough();
    }

}
