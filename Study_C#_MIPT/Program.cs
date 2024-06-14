using System.ComponentModel.Design;

namespace Study_C__MIPT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задача 1
            //Console.WriteLine("Введите длину прямоугольника");
            //double a = Convert.ToDouble(Console.ReadLine());


            //Console.WriteLine("Введите ширину прямоугольника");
            //double b = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine("Площадь прямоугольника равна {0}", (a * b));
            //Console.WriteLine("Периметр прямоугольника равен {0}", ((a + b) * 2));


            //// Задача 2
            //int summ = 0;

            //Console.WriteLine("Введите число n");
            //int n = Convert.ToInt32(Console.ReadLine());
            //for (int i = 1; i <= n; i++)
            //{
            //    summ = summ + i;
            //}
            //Console.WriteLine("Сумма чисел равна {0}", summ);


            // Задача 3

            for (float i = 35; i <= 87; i++)
            {
                if ((i % 7) == 1)
                {
                    Console.WriteLine(i);
                    Console.WriteLine("Остаток {0}", i % 7);
                }
                if ((i % 7.0) == 2)
                {
                    Console.WriteLine(i);
                    Console.WriteLine("Остаток {0}", i % 7);
                }
                if ((i % 7.0) == 5)
                {

                    Console.WriteLine(i);
                    Console.WriteLine("Остаток {0}", i % 7);
                }
            }

                // Задача 4

                int box = 20;

                while (box > 0) 
                {
                    Console.WriteLine("Количество ящиков на отгрузку");
                    int a = Convert.ToInt32(Console.ReadLine());

                    if (box < a)
                    {
                        Console.WriteLine("Такого количества на отгрузку нет, забирайте остаток");
                        Console.WriteLine("Отгруженно {0} ящиков", box);
                        box = 0;
                    }
                    else
                    {
                        box = box - a;
                        Console.WriteLine("Отгруженно {0} ящиков", a);
                    }
                }
            

        }
    }
}
