using System;
using System.Net.Http;
using System.Threading;

namespace _04.DistanceRestServiceClient
{
    class Program
    {
        static void Main()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:23815/api/Points");
            var query = "?startX=5&startY=5&endX=10&endY=10";
            PrintDistanceAsync(httpClient, query);
            Thread.Sleep(3000);
        }

        private async static void PrintDistanceAsync(HttpClient client, string query)
        {
            var response = await client.GetAsync(query);
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
    }
}
