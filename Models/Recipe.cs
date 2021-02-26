using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models
{
    public class Recipe
    {
        public Item CraftingResult { get; set; }
        public int ID { get; set; }
        public Dictionary<int, int> Ingredients { get; set; }

        [JsonPropertyName("output_item_id")]
        public int Item { get; set; }

        // TODO: Get result from API?
    }
}