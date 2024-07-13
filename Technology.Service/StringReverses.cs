using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Technology.Service
{
    public static class StringReverses
    {
        public static bool IsEven(this int number) => number % 2 == 0;
        public static string Even(string str)
        {
            string firstPart = str[..(str.Length / 2)];
            string secondPart = str[(str.Length / 2)..];
            return new string(firstPart.Reverse().Concat(secondPart.Reverse()).ToArray());
        }

        public static string Odd(string str)
        {
            return new string(str.Reverse().ToArray()) + str;
        }

        public static string ReverseByLenght(string str)
        {
            if (IsEven(str.Length))
                return Even(str);
            else
                return Odd(str);
        }

        public static Dictionary<string, int> CountLetters(string str)
        {
            Dictionary<string, int> letters = new Dictionary<string, int>();
            foreach (char letter in str)
            {
                if (letters.ContainsKey(letter.ToString()))
                    letters[letter.ToString()]++;
                else
                    letters.Add(letter.ToString(), 1);
            }
            return letters;
        }
    }
}
