using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using Technology.Service;
using Technology.Service.Randoms;

namespace Technology.Controllers
{
    [ApiController, Route("[controller]")]
    public class StringReverse : ControllerBase
    {
        public RandomClient RandomClient { get; set; }
        public ICollection<string> BlackList { get; set; }
        public StringReverse(RandomClient randomClient, ICollection<string> blackList)
        {
            RandomClient = randomClient;
            BlackList = blackList;
        }
        /// <summary>
        /// Reverses a string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="sortType">
        /// <remarks>
        /// SortType can be 'quick' or 'tree'
        /// </remarks>
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(string input, string sortType = "quick")
        {
            
            char[] count = Validation.WrongLetters(input).ToArray();
            try
            {
                if (count.Length != 0)
                    throw new Exception($"Wrong Letters: {new string(count)}");
                if (BlackList == null)
                    throw new Exception("BlackList is empty");
                if (BlackList.Contains(input))
                    throw new Exception($"BlackList: {input}");
                string result = StringReverses.ReverseByLenght(input);
                JsonObject json = new JsonObject()
                {
                    ["reversed_string"] = result,
                    ["details"] = JsonSerializer.SerializeToNode(StringReverses.CountLetters(result)),
                    ["longest_substring"] = StringReverses.LongestSubstring(result),
                    ["sorted_string"] = StringReverses.Sort(result, sortType),
                    ["truncate_string"] = TruncateString.Truncate(result, RandomClient)
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
