using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using Technology.Service;

namespace Technology.Controllers
{
    [ApiController, Route("[controller]")]
    public class StringReverse : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(string input, string sortType = "quick")
        {
            char[] count = Validation.WrongLetters(input).ToArray();
            try
            {
                if (count.Length != 0)
                    throw new Exception($"Wrong Letters: {new string(count)}");
                string result = StringReverses.ReverseByLenght(input);
                JsonObject json = new JsonObject()
                {
                    ["reversed_string"] = result,
                    ["details"] = JsonSerializer.SerializeToNode(StringReverses.CountLetters(result)),
                    ["longest_substring"] = StringReverses.LongestSubstring(result),
                    ["sorted_string"] = StringReverses.Sort(result, sortType)
                };
                return Ok(json);
            }
            catch(Exception exception)
            {
                return BadRequest(new JsonObject() { ["error"] = exception.Message });
            }
        }
    }
}
