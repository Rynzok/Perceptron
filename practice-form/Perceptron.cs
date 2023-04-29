using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            weights = new int[4, 25];
            //Genetic_Algoritm.Main();
            int N = 100;
            Population population = new Population(N, 0);
            // Цифры (Обучающая выборка)
            var n0 = "0010001010100010000000000".ToCharArray();
            var n1 = "0000000000100010101000100".ToCharArray();
            var n2 = "0010000010111110001000100".ToCharArray();
            var n3 = "0010000100001000000000100".ToCharArray();


            // Список всех вышеуказанных цифр
            char[][] nums = { n0, n1, n2, n3 };
            //Char[] symbols = new char[4]{ '˄', '˅', '→', '!'};

            // Тренировка сети
            for (int n = 0; n <4; n++)
            {
                for (int i = 0; i < trainings; i++)
                {
                    var option = random.Next(0, 4);
                    for (int j = 0; j < population.ind.Length ; j++)
                    {
                        int net = proceed(nums[option], population.ind[j].weights);
                        if (net >= bias & nums[option].SequenceEqual(nums[n])) population.ind[j].positive_response++;
                        population.ind[j].value = Genetic_Algoritm.GetValue(population.ind[j].positive_response, population.ind[j].sum_weights);
                        //Console.WriteLine("Осыбь номер: " + j + " Кол. утв. ответов: " + population.ind[j].positive_response + " Рейтинг: " + population.ind[j].value);

                    }
                    //Console.WriteLine("Чё?");
                    population.Copulation(population.ind);
                    Console.WriteLine("Популяция номер - " + population.x);
                }
                Array.Sort(population.ind, (x, y) => x.sum_weights.CompareTo(y.sum_weights));
                for (int i = 0; i < 25; i++)
                {
                    weights[n,i] = population.ind[0].weights[i];
                    //Console.WriteLine(population.ind[0].weights[i]);
                }
                Console.WriteLine("WTF?");
            }
        }

        public static int proceed(char[] base_number, int [] weights)
        {
            // Рассчитываем взвешенную сумму
            var net = 0;
            for (int i = 0; i < base_number.Length; i++)
            {
                net += int.Parse(base_number[i].ToString()) * weights[i];
            }
            

            // Возвращаем разницу
            return net;
        }

        public static bool Comparison(char[] base_number, int RightNumbers)
        {
            // Рассчитываем взвешенную сумму
            var net = 0;
            for (int i = 0; i < base_number.Length; i++)
            {
                net += int.Parse(base_number[i].ToString()) * weights[RightNumbers, i];
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
