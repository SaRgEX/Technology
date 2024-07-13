using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json.Nodes;
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
                return new OkObjectResult(StringReverses.ReverseByLenght(input));
            return new BadRequestObjectResult("Wrong letters: " + new string(count));
        }
    }
}
