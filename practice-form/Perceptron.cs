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
            weights = new int[4, 25];
            //Genetic_Algoritm.Main();
            int N = 100;
            Population population = new Population(N, 0);
            // Цифры (Обучающая выборка)
            //var num0 = "0010001010100010000000000".ToCharArray();
            //var num1 = "0000000000100010101000100".ToCharArray();
            //var num2 = "0010000010111110001000100".ToCharArray();
            //var num3 = "0010000100001000000000100".ToCharArray();


            // Список всех вышеуказанных цифр
            //char[][] nums = { num0, num1, num2, num3 };
            //Character_Base numbers = new Character_Base();
            //numbers.Create_Base();
            //Char[] symbols = new char[4]{ '˄', '˅', '→', '!'};

            var num0 = "0010001010100010000000000".ToCharArray(); // Верный
            var num1 = "0010011010100010000000000".ToCharArray(); // Малое искажение
            var num2 = "0010001010100010000000000".ToCharArray(); // Верный
            var num3 = "0000001010101010010000111".ToCharArray(); // Не Верный
            var num4 = "0010001010100000000000000".ToCharArray(); // Малое искажение
            var num5 = "0000000000100010001000011".ToCharArray(); // Не Верный
            var num6 = "0010001010101110000000000".ToCharArray(); // Большое искажение
            var num7 = "0010001010100010000000000".ToCharArray(); // Верный
            var num8 = "0010001010100011000000000".ToCharArray(); // Малое искажение
            var num9 = "0010010011100000101010100".ToCharArray(); // Не Верный

            char[][] base_nums1 = { num0, num1, num2, num3, num4, num5, num6, num7, num8, num9 }; // База для ˄

            var num10 = "0000000000100010101000100".ToCharArray();
            var num11 = "0000000000100010101000100".ToCharArray();
            var num12 = "0000000000100010101000100".ToCharArray();
            var num13 = "0000000000100010101000100".ToCharArray();
            var num14 = "0000000000100010101000100".ToCharArray();
            var num15 = "0000000000100010101000100".ToCharArray();
            var num16 = "0000000000100010101000100".ToCharArray();
            var num17 = "0000000000100010101000100".ToCharArray();
            var num18 = "0000000000100010101000100".ToCharArray();
            var num19 = "0000000000100010101000100".ToCharArray();

            char[][] base_nums2 = { num10, num11, num12, num13, num14, num15, num16, num17, num18, num19 }; // База для ˅

            var num20 = "0010000010111110001000100".ToCharArray();
            var num21 = "0010000010111110001000100".ToCharArray();
            var num22 = "0010000010111110001000100".ToCharArray();
            var num23 = "0010000010111110001000100".ToCharArray();
            var num24 = "0010000010111110001000100".ToCharArray();
            var num25 = "0010000010111110001000100".ToCharArray();
            var num26 = "0010000010111110001000100".ToCharArray();
            var num27 = "0010000010111110001000100".ToCharArray();
            var num28 = "0010000010111110001000100".ToCharArray();
            var num29 = "0010000010111110001000100".ToCharArray();


            char[][] base_nums3 = { num20, num21, num22, num23, num24, num25, num26, num27, num28, num29 }; // База для →

            var num30 = "0010000100001000000000100".ToCharArray();
            var num31 = "0010000100001000000000100".ToCharArray();
            var num32 = "0010000100001000000000100".ToCharArray();
            var num33 = "0010000100001000000000100".ToCharArray();
            var num34 = "0010000100001000000000100".ToCharArray();
            var num35 = "0010000100001000000000100".ToCharArray();
            var num36 = "0010000100001000000000100".ToCharArray();
            var num37 = "0010000100001000000000100".ToCharArray();
            var num38 = "0010000100001000000000100".ToCharArray();
            var num39 = "0010000100001000000000100".ToCharArray();


            char[][] base_nums4 = { num30, num31, num32, num33, num34, num35, num36, num37, num38, num39 }; // База для !

            // Тренировка сети
            for (int n = 0; n <4; n++)
            {
                for (int i = 0; i < trainings; i++)
                {
                    for (int j = 0; j < population.ind.Length ; j++)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            switch(n)
                            {
                                case 0: if (proceed(base_nums1[k], population.ind[j].weights))
                                        population.ind[j].value++;
                                    break;
                                case 1: if (proceed(base_nums2[k], population.ind[j].weights))
                                        population.ind[j].value++;
                                    break;
                                case 2: if (proceed(base_nums3[k], population.ind[j].weights))
                                        population.ind[j].value++;
                                    break;
                                case 3: if (proceed(base_nums4[k], population.ind[j].weights))
                                        population.ind[j].value++;
                                    break;

                            }
                            
                            //Console.WriteLine("Чё?");
                        }
                        if (population.ind[j].value == 7) population.ind[j].value = 1;
                    }
                    //Console.WriteLine("Чё?");
                    population.Copulation(population.ind);
                    Console.WriteLine("Номер популяции - " + population.x);
                }
                for (int i = 0; i < 25; i++)
                {
                    weights[n,i] = population.ind[0].weights[i];
                    //Console.WriteLine(population.ind[0].weights[i]);
                }
                Console.WriteLine("WTF?");
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
