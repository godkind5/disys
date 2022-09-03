using System;
using System.Collections;
using System.Collections.Generic;

namespace disys
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList xySystems = new ArrayList();
            // abcaaaabacabbacbbaccbbaccbbddadadaa
            Console.Write("Введите значение для числа наблюдений для системы X: ");
            string xValue = Console.ReadLine();
            xySystems.Add(xValue);

            // acabacabbacbbaccabcabbaccbbddadadaa
            Console.Write("Введите значение для числа наблюдений для системы Y: ");
            string yValue = Console.ReadLine();
            xySystems.Add(yValue);

            GetSymbolAmount(xySystems);
        }

        private static void GetSymbolAmount(ArrayList xySystems)
        {
            Console.WriteLine("________________________________________________\n");

            int iterator = 1;

            Console.WriteLine("Нахождение общего количества символов для систем");
            foreach (string xyValues in xySystems)
            {
                Console.WriteLine($"Всего символов в {iterator}-ой системе: {xyValues.Length}. Значение: {xyValues}");
                iterator++;
            }
            Console.WriteLine("________________________________________________\n");

            GetLettersAmount(xySystems);
        }

        private static void GetLettersAmount(ArrayList xySystems)
        {
            int aIterator = 0;
            int bIterator = 0;
            int cIterator = 0;
            int dIterator = 0;

            double total = 0;


            List<int> iterators = new List<int>();

            Console.WriteLine("Подсчет количества каждого символа");
            foreach (string xyValues in xySystems)
            {
                foreach (char symbol in xyValues)
                {
                    if (symbol == 'a')
                    {
                        aIterator++;
                    }
                    if (symbol == 'b')
                    {
                        bIterator++;
                    }
                    if (symbol == 'c')
                    {
                        cIterator++;
                    }
                    if (symbol == 'd')
                    {
                        dIterator++;
                    }
                }
                Console.WriteLine("A\tB\tC\tD");
                Console.WriteLine($"{aIterator}\t{bIterator}\t{cIterator}\t{dIterator}\n");


                iterators.Add(aIterator);
                iterators.Add(bIterator);
                iterators.Add(cIterator);
                iterators.Add(dIterator);

                total = xyValues.Length;

                aIterator = 0;
                bIterator = 0;
                cIterator = 0;
                dIterator = 0;
            }
            Console.WriteLine("________________________________________________\n");
            GetProbability(iterators, total);
        }

        private static void GetProbability(List<int> iterators, double total)
        {
            List<double> probability = new List<double>();
            Console.WriteLine("Находим вероятность для каждой системы");
            Console.Write($"X\tX\tX\tX\tY\tY\tY\tY\n");
            double temp = 0.0;
            foreach (int i in iterators)
            {
                temp = i / total;
                Console.Write($"{Math.Round(temp, 3)}\t");
                probability.Add(temp);
            }
            Console.WriteLine();

            double sumX = 0.0;
            double sumY = 0.0;
            sumX = probability[0] + probability[1] + probability[2] + probability[3];
            sumY = probability[4] + probability[5] + probability[6] + probability[7];
            Console.WriteLine($"\nСумма вероятностей X = {sumX}, Y = {sumY}");

            Console.WriteLine("________________________________________________\n");
            Entropy.IndependentSystems(probability);
        }


    }
}
