using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace FavoriteToppings
{
    public class Pizzas
    {
        [JsonProperty("Toppings")]
        public List<string> Toppings { get; set; }

        public override string ToString()
        {
            if (Toppings == null || !Toppings.Any())
            {
                return "No toppings";
            }

            //return Toppings.OrderBy(x => x).Aggregate((a, x) => a + ", " + x);

            return string.Join(", ", Toppings.OrderBy(x => x));
        
        }
    }

}