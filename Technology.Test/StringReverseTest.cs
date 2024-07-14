using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technology.Service;

namespace Technology.Test
{
    public class StringReverseTest
    {
        [TestCase("a", "aa")]
        [TestCase("abcdef", "cbafed")]
        [TestCase("abcde", "edcbaabcde")]
        [TestCase("", "")]
        public void ReverseStringTest(string input, string expectedOutput)
        {
            var result = StringReverses.ReverseByLenght(input);

            Assert.That(result, Is.EqualTo(expectedOutput));
        }
        [TestCase("abc", new char[] {})]
        [TestCase("aBc", new char[] { 'B' })]
        [TestCase("Abc1", new char[] { 'A', '1' })]
        public void WrongLetter(string input, IEnumerable<char> expectedOutput)
        {
            var result = Validation.WrongLetters(input);
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [TestCaseSource(typeof(StringReverseData), nameof(StringReverseData.Counter))]
        public void LettersCount(string input, Dictionary<string, int> expectedOutput)
        {
            var result = StringReverses.CountLetters(input);
            Assert.That(result, Is.EqualTo(expectedOutput));
        }
        [TestCase("abc", "")]
        [TestCase("a", "")]
        [TestCase("abcde", "abcde")]
        [TestCase("defaafed", "efaafe")]
        [TestCase("abadb", "aba")]
        public void LongestSubstring(string input, string expectedOutput)
        {
            var result = StringReverses.LongestSubstring(input);
            Assert.That(result, Is.EqualTo(expectedOutput));
        }
        [TestCase("asdb", "quick", "abds")]
        [TestCase("qwerty", "tree", "eqrtwy")]
        public void Sorts(string input, string type, string expectedOutput)
        {
            var result = StringReverses.Sort(input, type);
            Assert.That(result, Is.EqualTo(expectedOutput));
        }
    }
}
