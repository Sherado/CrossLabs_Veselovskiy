using System;
using System.IO;

namespace Laba_2
{
    class Program
    {
        private const string InputFileName = "INPUT.txt";
        private const string OutputFileName = "OUTPUT.txt";

        private static int Number;

        static void Main(string[] args)
        {
            ReadFile();

            Console.WriteLine(Progression(Number));
            WriteToFile(Progression(Number));
        }

        private static int Progression(int inputNumber)
        {
            var depth = 1;
            for (int i = 1; i < int.MaxValue; i++)
            {
                if (i % 2 == 0)
                {
                    depth += 1;
                }
                else if (i % 3 == 0)
                {
                    depth += 1;
                }
                else if (i % 5 == 0)
                {
                    depth += 1;
                }
                if (depth == inputNumber)
                {
                    return i;
                }
            }
            return 0;
        }
        private static void ReadFile()
        {
            if (File.Exists(InputFileName) == false)
            {
                Console.WriteLine("Файл не существует");
                return;
            }

            var result = File.ReadAllLines(InputFileName);
            if (int.TryParse(result[0], out int value) && value >= 1)
            {
                if (value > 10000)
                {
                    Console.WriteLine("значение должно быть меньше 10000. Ошибка");
                }
                Number = value;
            }
            else { Console.WriteLine("Not a number"); }
        }
        private static void WriteToFile(int overlap)
        {
            if (File.Exists(OutputFileName) == true)
            {
                File.WriteAllText(OutputFileName, overlap.ToString());
            }
        }
    }
}
