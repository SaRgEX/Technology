using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Technology.Service;

namespace Technology.Controllers
{
    [ApiController]
    public class StringReverse
    {
        [HttpPost("/reverse")]
        public string Reverse(string input)
        {
            return StringReverses.ReverseByLenght(input);
        }
    }
}
