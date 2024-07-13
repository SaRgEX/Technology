using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Technology.Service.Sorts;
using Technology.Service.Sorts.Tree;
using static System.Net.Mime.MediaTypeNames;

namespace Technology.Service
{
    public static class StringReverses
    {
        public static bool IsEven(this int number) => number % 2 == 0;
        public static string Even(string origin)
        {
            string firstPart = origin[..(origin.Length / 2)];
            string secondPart = origin[(origin.Length / 2)..];
            return new string(firstPart.Reverse().Concat(secondPart.Reverse()).ToArray());
        }

        public static string Odd(string origin)
        {
            return new string(origin.Reverse().ToArray()) + origin;
        }

        public static string ReverseByLenght(string origin)
        {
            if (IsEven(origin.Length))
                return Even(origin);
            else
                return Odd(origin);
        }

        public static Dictionary<string, int> CountLetters(string origin)
        {
            Dictionary<string, int> letters = new Dictionary<string, int>();
            foreach (char letter in origin)
            {
                if (letters.ContainsKey(letter.ToString()))
                    letters[letter.ToString()]++;
                else
                    letters.Add(letter.ToString(), 1);
            }
            return letters;
        }

        public static string LongestSubstring(string origin)
        {
            Regex regex = new Regex(@"[aeiou].*[aeiou]");
            return regex.Match(origin).Value;
        }

        public static string Sort(string origin, string type)
        {
            if (!SortMethods.ContainsKey(type))
                throw new Exception("Invalid sort type");
            return SortMethods[type](origin);
        }

        public static Dictionary<string, Sort> SortMethods = new()
        {
            ["quick"] = QuickSort.Sort,
            ["tree"] = TreeSort.Sort
        };
    }
}
