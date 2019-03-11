using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace FavoriteToppings
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string json = await GetJsonAsync(client);

            var pizzas = JsonConvert.DeserializeObject<List<Pizzas>>(json);
            Console.WriteLine($"Found {pizzas.Count} pizzas");

            var pizzaStats = pizzas
                .Select(p => p.ToString())
                .GroupBy(p => p)
                .OrderByDescending(t => t.Count())
                .Select(s => new { s.Key, Number = s.Count() });

            var top20Pizzas = pizzaStats.Take(20);

            Console.WriteLine("\nStats of the Top 20 Pizzas and Toppings\n");

            foreach (var pizza in top20Pizzas)
            {
                Console.WriteLine("\tCount: {0,5}, \t\tToppings {1}", pizza.Number, pizza.Key);
            }

            Console.ReadLine();

        }
        static async Task<string> GetJsonAsync(HttpClient client)
        {
            var result = await client.GetStringAsync("http://files.olo.com/pizzas.json");

            return result;
        }
    }
}
