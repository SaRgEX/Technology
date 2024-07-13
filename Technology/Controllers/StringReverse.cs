using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Technology.Service;

namespace Technology.Controllers
{
    [ApiController, Route("[controller]")]
    public class StringReverse : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(string input)
        {
            char[] count = Validation.WrongLetters(input).ToArray();
            if (count.Length == 0)
            {
                string result = StringReverses.ReverseByLenght(input);
                JsonObject json = new JsonObject()
                {
                    ["reversed_string"] = result,
                    ["details"] = JsonSerializer.SerializeToNode(StringReverses.CountLetters(result)),
                };
                return Ok(json);
            }
            return BadRequest(new JsonObject() { ["Wrong letters"] = new string(count) });
        }
    }
}
