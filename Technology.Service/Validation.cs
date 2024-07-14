using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technology.Service
{
    public class Validation
    {
        public static IEnumerable<char> WrongLetters (string input)
        {
            foreach (char letter in input)
            {
                if (letter < 'a' || letter > 'z')
                    yield return letter;
            }
        }

    }
}
