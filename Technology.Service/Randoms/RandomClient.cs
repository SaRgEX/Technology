using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Technology.Service.Randoms
{
    public class RandomClient
    {
        private readonly string? url;
        public RandomClient(string url)
        {
            this.url = url;
        }

        public async Task<int> RandomNumber(int length)
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
    }
}
