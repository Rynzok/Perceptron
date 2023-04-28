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
            var num40 = "1111111111111111111111111".ToCharArray(); // Не Верный
            var num41 = "1111110011110111111000111".ToCharArray(); // Не Верный
            var num42 = "0001111111110000110111001".ToCharArray(); // Не Верный
            var num43 = "1111111011111111111011111".ToCharArray(); // Не Верный
            var num44 = "1101101111101111101101110".ToCharArray(); // Не Верный
            var num45 = "1010011110001110101010100".ToCharArray(); // Не Верный
            var num46 = "0010010011111111100000000".ToCharArray(); // Не Верный
            var num47 = "0000010000000000000010100".ToCharArray(); // Не Верный
            var num48 = "0000000000000000000000000".ToCharArray(); // Не Верный
            var num49 = "1111111111111100000000000".ToCharArray(); // Не Верный




            char[][] base_nums1 = { num0, num1, num2, num3, num4, num5, num6, num7, num8, num9, num40, num41, num42, num43, num44, num45, num46, num47, num48, num49 }; // База для ˄

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
            var num50 = "0000000000100010101000100".ToCharArray();
            var num51 = "0000000000100010101000100".ToCharArray();
            var num52 = "0000000000100010101000100".ToCharArray();
            var num53 = "0000000000100010101000100".ToCharArray();
            var num54 = "0000000000100010101000100".ToCharArray();
            var num55 = "0000000000100010101000100".ToCharArray();
            var num56 = "0000000000100010101000100".ToCharArray();
            var num57 = "0000000000100010101000100".ToCharArray();
            var num58 = "0000000000100010101000100".ToCharArray();
            var num59 = "0000000000100010101000100".ToCharArray();

            char[][] base_nums2 = { num10, num11, num12, num13, num14, num15, num16, num17, num18, num19, num50, num51, num52, num53, num54, num55, num56, num57, num58, num59 }; // База для ˅

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
            var num60 = "0010000010111110001000100".ToCharArray();
            var num61 = "0010000010111110001000100".ToCharArray();
            var num62 = "0010000010111110001000100".ToCharArray();
            var num63 = "0010000010111110001000100".ToCharArray();
            var num64 = "0010000010111110001000100".ToCharArray();
            var num65 = "0010000010111110001000100".ToCharArray();
            var num66 = "0010000010111110001000100".ToCharArray();
            var num67 = "0010000010111110001000100".ToCharArray();
            var num68 = "0010000010111110001000100".ToCharArray();
            var num69 = "0010000010111110001000100".ToCharArray();


            char[][] base_nums3 = { num20, num21, num22, num23, num24, num25, num26, num27, num28, num29, num60, num61, num62, num63, num64, num65, num66, num67, num68, num69 }; // База для →

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
            var num70 = "0010000100001000000000100".ToCharArray();
            var num71 = "0010000100001000000000100".ToCharArray();
            var num72 = "0010000100001000000000100".ToCharArray();
            var num73 = "0010000100001000000000100".ToCharArray();
            var num74 = "0010000100001000000000100".ToCharArray();
            var num75 = "0010000100001000000000100".ToCharArray();
            var num76 = "0010000100001000000000100".ToCharArray();
            var num77 = "0010000100001000000000100".ToCharArray();
            var num78 = "0010000100001000000000100".ToCharArray();
            var num79 = "0010000100001000000000100".ToCharArray();


            char[][] base_nums4 = { num30, num31, num32, num33, num34, num35, num36, num37, num38, num39, num70, num71, num72, num73, num74, num75, num76, num77, num78, num79 }; // База для !

            // Тренировка сети
            for (int n = 0; n <4; n++)
            {
                for (int i = 0; i < trainings; i++)
                {
                    for (int j = 0; j < population.ind.Length ; j++)
                    {
                        for (int k = 0; k < 20; k++)
                        {
                            switch(n)
                            {
                                case 0: if (proceed(base_nums1[k], population.ind[j].weights))
                                        population.ind[j].positive_response++;
                                    break;
                                case 1: if (proceed(base_nums2[k], population.ind[j].weights))
                                        population.ind[j].positive_response++;
                                    break;
                                case 2: if (proceed(base_nums3[k], population.ind[j].weights))
                                        population.ind[j].positive_response++;
                                    break;
                                case 3: if (proceed(base_nums4[k], population.ind[j].weights))
                                        population.ind[j].positive_response++;
                                    break;

                            }
                            
                            //Console.WriteLine("Чё?");
                        }
                        population.ind[j].value = Genetic_Algoritm.GetValue(population.ind[j].positive_response);

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
