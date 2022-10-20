using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab_1
{
    class Program
    {
        private const string InputFileName = "INPUT.txt";
        private const string OutputFileName = "OUTPUT.txt";
        private static string Str1;
        private static string Str2;

        private static Dictionary<char, List<int>> dictionary = new Dictionary<char, List<int>>()
        {
            { 'a',new List<int>(){ 0, 1 , 2, 3 }},
            { 'b',new List<int>(){ 1, 2 , 3, 4 }},
            { 'c',new List<int>(){ 2, 3 , 4, 5 }},
            { 'd',new List<int>(){ 3, 4 , 5, 6 }},
            { 'e',new List<int>(){ 4, 5 , 6, 7 }},
            { 'f',new List<int>(){ 5, 6 , 7, 8 }},
            { 'g',new List<int>(){ 6, 7 , 8, 9 }},
            { '?',new List<int>(){ 0 ,1 , 2, 3, 4, 5, 6, 7, 8, 9 }},

            { '0',new List<int>(){ 0}},
            { '1',new List<int>(){ 1}},
            { '2',new List<int>(){ 2}},
            { '3',new List<int>(){ 3}},
            { '4',new List<int>(){ 4}},
            { '5',new List<int>(){ 5}},
            { '6',new List<int>(){ 6}},
            { '7',new List<int>(){ 7}},
            { '8',new List<int>(){ 8}},
            { '9',new List<int>(){ 9}},
        };
        static void Main(string[] args)
        {
            ReadFile(ref Str1, ref Str2);
            if (IfStringLengthIsEqual(Str1, Str2) == true)
            {
                Console.WriteLine(Analyze(Str1, Str2));
                WriteToFile(Analyze(Str1, Str2));
            }
            return;
        }
        private static int Analyze(string str1, string str2)
        {
            int counter = 1;
            for (int i = 0; i < str1.Length; i++)
            {
                if (dictionary.TryGetValue(str1[i], out var val) && dictionary.TryGetValue(str2[i], out var val2))
                {
                    counter *= Compare(dictionary[str1[i]], dictionary[str2[i]]);
                }
                else 
                {
                    Console.WriteLine("Зпрещенный символ");
                    return 0;
                }

            }
            return counter;
        }
        private static int Compare(List<int> list1, List<int> list2)
        {
            var count = 0;
            count = list1.Count(x => list2.Contains(x));
            return count;
        }
        private static bool IfStringLengthIsEqual(string str1, string str2)
        {
            if (str1 == null || str2 == null)
            {
                return false;
            }
            if (str1.Length != str2.Length)
            {
                Console.WriteLine("Строки разных длинн");
                return false;     
            }
            return true;
        }
        private static void ReadFile(ref string str1, ref string str2)
        {
            if (File.Exists(InputFileName) == false)
            {
                Console.WriteLine("Файл не существует");
            }

            var strings = File.ReadAllLines(InputFileName);
            if (strings.Length > 2)
            {
                Console.WriteLine("Больше 2-x строк");
                return;
            } 
            if (strings.Length < 2)
            {
                Console.WriteLine("Файл сломан...");
                return;
            }
            str1 = strings[0];
            str2 = strings[1];
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
