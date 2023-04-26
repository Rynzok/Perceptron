using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static practice_form.Genetic_Algoritm;

namespace practice_form
{
    class Perceptron
    {
        // Инициализация весов сети
        public static int[,] weights { get; private set; }

        // Порог функции активации
        public static int bias { get; set; }

        public static int trainings { get; set; }

        private static Random random = new Random(Guid.NewGuid().GetHashCode());

        public static void training()
        {
            //weights = new int[4, 25];
            //Genetic_Algoritm.Main();
            int N = 100;
            Population population = new Population(N, 0);
            // Цифры (Обучающая выборка)
            var num0 = "0010001010100010000000000".ToCharArray();
            var num1 = "0000000000100010101000100".ToCharArray();
            var num2 = "0010000010111110001000100".ToCharArray();
            var num3 = "0010000100001000000000100".ToCharArray();


            // Список всех вышеуказанных цифр
            char[][] nums = { num0, num1, num2, num3 };


            //Char[] symbols = new char[4]{ '˄', '˅', '→', '!'};

            // Тренировка сети
            for (int i = 0; i < trainings; i++)
            {
                for (int j = 0; j < population.ind.Length ; j++)
                {
                    for (int k = 0; k < Character_Base.base_nums.Length; k++)
                    {
                        if (proceed(Character_Base.base_nums[k], population.ind[j].weights)) population.ind[j].value++;
                    }
                    
                }
                population.Copulation(population.ind);
                // Генерируем случайное число от 0 до 9
                //var option = random.Next(0, 4);

                //for (int j = 0; j < 4; j++)
                //{
                //    if (option != j)
                //    {
                //        if (proceed(nums[option], j)) decrease(nums[option], j);
                //    }
                //    else
                //    {
                //        if (!proceed(nums[j], j)) increase(nums[j], j);
                //    }
                //}
            }
        }

        public static bool proceed(char[] base_number, int [] weights)
        {
            // Рассчитываем взвешенную сумму
            var net = 0;
            for (int i = 0; i < base_number.Length; i++)
            {
                net += int.Parse(base_number[i].ToString()) * weights[i];
            }

            // Превышен ли порог? (Да - сеть думает, что это 5. Нет - сеть думает, что это другая цифра)
            return net >= bias;
        }

        // Уменьшение значений весов, если сеть ошиблась и выдала 1
        //private static void decrease(char[] number, int rightNum)
        //{
        //    for (int i = 0; i < 25; i++)
        //    {
        //        // Возбужденный ли вход
        //        if (int.Parse(number[i].ToString()) == 1)
        //        {
        //            // Уменьшаем связанный с ним вес на единицу
        //            weights[rightNum, i]--;
        //        }
        //    }
        //}

        // Увеличение значений весов, если сеть ошиблась и выдала 0
        //private static void increase(char[] number, int rightNum)
        //{
        //    for (int i = 0; i < 25; i++)
        //    {
        //        // Возбужденный ли вход
        //        if (int.Parse(number[i].ToString()) == 1)
        //        {
        //            // Увеличиваем связанный с ним вес на единицу
        //            weights[rightNum, i]++;
        //        }
        //    }
        //}
    }
}
