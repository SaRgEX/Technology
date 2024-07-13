using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Technology.Service
{
    public class TruncateString
    {
        public static string Truncate(string origin)
        {
            int result = RandomGenerator.RandomApi(origin.Length).Result;
            if (result != -1)
                return origin.Remove(result, 1);
            result = RandomGenerator.RandomNumberByLenght(origin.Length);
            return origin.Remove(result, 1);
        }
    }
}
