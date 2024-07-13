using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Technology.Service;

namespace Technology.Controllers
{
    [ApiController, Route("[controller]")]
    public class StringReverse
    {
        [HttpPost]
        public IActionResult Post(string input)
        {
            char[] count = Validation.WrongLetters(input).ToArray();
            if (count.Length == 0)
            {
                (string, Dictionary<char, int>) result = StringReverses.StringDetails(input);
                string dictionary = result.Item2
                    .Select(x => $"{x.Key}: {x.Value}")
                    .Aggregate((x, y) => x + "\n" + y);
                return new OkObjectResult(result.Item1 + "\n" + dictionary);
            }
            return new BadRequestObjectResult("Wrong letters: " + new string(count));
        }
    }
}
