using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Technology.Service.Randoms;

namespace Technology.Service
{
    public class TruncateString
    {
        public static string Truncate(string origin, RandomClient randomClient)
        {
            int result = randomClient.RandomNumber(origin.Length).Result;
            if (result != -1)
                return origin.Remove(result, 1);
            result = new Random().Next(origin.Length);
            return origin.Remove(result, 1);
        }
    }
}
