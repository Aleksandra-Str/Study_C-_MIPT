using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    public class TaxiState
    {
        // Определение интерфейса состояния для паттерна Состояние
        public interface ITaxiState
        {
            void Start(TaxiContext context);
            void Stop(TaxiContext context);
        }

        // Реализация состояния "Стоит"
        public class IdleState : ITaxiState
        {
            public void Start(TaxiContext context)
            {
                Console.WriteLine("Автомобиль начинает движение.");
                context.SetState(new MovingState());
            }

            public void Stop(TaxiContext context)
            {
                Console.WriteLine("Автомобиль уже стоит.");
            }
        }

        // Реализация состояния "Движется"
        public class MovingState : ITaxiState
        {
            public void Start(TaxiContext context)
            {
                Console.WriteLine("Автомобиль уже движется.");
            }

            public void Stop(TaxiContext context)
            {
                Console.WriteLine("Автомобиль останавливается.");
                context.SetState(new IdleState());
            }
        }

        // Класс для управления состояниями такси
        public class TaxiContext
        {
            private ITaxiState _state;

            public TaxiContext()
            {
                _state = new IdleState(); // Начальное состояние
            }

            // Метод для смены состояния
            public void SetState(ITaxiState state)
            {
                _state = state;
            }

            // Метод для начала движения
            public void Start()
            {
                _state.Start(this);
            }

            // Метод для остановки
            public void Stop()
            {
                _state.Stop(this);
            }
        }



    }
}
