using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models
{
    public class Recipe
    {
        public int ID { get; set; }
        [JsonPropertyName("output_item_id")]
        public int Item { get; set; }
        public Dictionary<int,int> Ingredients { get; set; }
        public Item CraftingResult { get; set; } // TODO: Get result from API?
    }
}
