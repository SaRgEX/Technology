using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technology.Service.Sorts;
using Technology.Service.Sorts.Tree;

namespace Technology.Test
{
    public class StringReverseData
    {
        public static TestCaseData[] Counter { get; set; } =
        {
        new TestCaseData("abfe", new Dictionary<string, int>
        {
            { "a", 1 },
            { "b", 1 },
            { "f", 1 },
            { "e", 1 }
        }),
        new TestCaseData("abbce", new Dictionary<string, int>
        {
            { "a", 1 },
            { "b", 2 },
            { "c", 1 },
            { "e", 1 }
        })
        };
        public static TestCaseData[] Sorts { get; set; } =
        {
        new TestCaseData("bfeada", QuickSort.Sort, "aabdef").SetName("Sorting a string using QuickSort"),
        new TestCaseData("sjhfsa", TreeSort.Sort, "afhjss").SetName("Sorting a string using TreeSort")
        };
    }
}
