using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Technology.Service
{
    public static class RandomGenerator
    {
        const string url = "http://www.randomnumberapi.com/api/v1.0/random?max=";
        public static async Task<int> RandomApi(int length)
        {
            using HttpClient client = new();
            HttpResponseMessage response;
            try
            {
                response = await client.GetAsync(url + (length - 1).ToString());
            }
            catch
            {
                return -1;
            }
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                int num = JsonSerializer.Deserialize<int[]>(result)[0];
                return num;
            }
            return -1;
        }
        public static int RandomNumberByLenght(int lenght) => new Random().Next(lenght - 1);
    }
}
