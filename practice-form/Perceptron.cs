using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_form
{
    class Perceptron
    {
        // Инициализация весов сети
        private static int[,] weights;

        static public int[,] Weights
        {
            get
            {
                return weights;
            }
        }

        // Порог функции активации
        public static int bias { get; set; }

        public static int trainings { get; set; }

        private static Random random = new Random(Guid.NewGuid().GetHashCode());

        public static void training()
        {
            weights = new int[10, 15];
            // Цифры (Обучающая выборка)
            var num0 = "111101101101111".ToCharArray();
            var num1 = "001001001001001".ToCharArray();
            var num2 = "111001111100111".ToCharArray();
            var num3 = "111001111001111".ToCharArray();
            var num4 = "101101111001001".ToCharArray();
            var num5 = "111100111001111".ToCharArray();
            var num6 = "111100111101111".ToCharArray();
            var num7 = "111001001001001".ToCharArray();
            var num8 = "111101111101111".ToCharArray();
            var num9 = "111101111001111".ToCharArray();

            // Список всех вышеуказанных цифр
            char[][] nums = { num0, num1, num2, num3, num4, num5, num6, num7, num8, num9 };

            // Виды цифры 5 (Тестовая выборка)
            var num51 = "111100111000111".ToCharArray();
            var num52 = "111100010001111".ToCharArray();
            var num53 = "111100011001111".ToCharArray();
            var num54 = "110100111001111".ToCharArray();
            var num55 = "110100111001011".ToCharArray();
            var num56 = "111100101001111".ToCharArray();
            var num10 = "001001000001001".ToCharArray();

            // Тренировка сети
            for (int i = 0; i < trainings; i++)
            {
                // Генерируем случайное число от 0 до 9
                var option = random.Next(0, 9 + 1);

                for (int j = 0; j < 10; j++)
                {
                    if (option != j)
                    {
                        if (proceed(nums[option], j)) decrease(nums[option], j);
                    }
                    else
                    {
                        if (!proceed(nums[j], j)) increase(nums[j], j);
                    }
                }
            }
        }

        public static bool proceed(char[] number, int rightNum)
        {
            // Рассчитываем взвешенную сумму
            var net = 0;
            for (int i = 0; i < 15; i++)
            {
                net += int.Parse(number[i].ToString()) * weights[rightNum, i];
            }

            // Превышен ли порог? (Да - сеть думает, что это 5. Нет - сеть думает, что это другая цифра)
            return net >= bias;
        }

        // Уменьшение значений весов, если сеть ошиблась и выдала 1
        private static void decrease(char[] number, int rightNum)
        {
            for (int i = 0; i < 15; i++)
            {
                // Возбужденный ли вход
                if (int.Parse(number[i].ToString()) == 1)
                {
                    // Уменьшаем связанный с ним вес на единицу
                    weights[rightNum, i]--;
                }
            }
        }

        // Увеличение значений весов, если сеть ошиблась и выдала 0
        private static void increase(char[] number, int rightNum)
        {
            for (int i = 0; i < 15; i++)
            {
                // Возбужденный ли вход
                if (int.Parse(number[i].ToString()) == 1)
                {
                    // Увеличиваем связанный с ним вес на единицу
                    weights[rightNum, i]++;
                }
            }
        }
    }
}
