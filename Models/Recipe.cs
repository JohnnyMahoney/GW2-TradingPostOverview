using System;

namespace Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Item[] Ingredients { get; set; }
        public int[] IngredientCounts { get; set; }
        public Item CraftingResult { get; } // TODO: Get result from API?

        public Recipe(params Item[] items)
        {
            Ingredients = items;
            IngredientCounts = new int[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                IngredientCounts[i] = 1;
            }
        }
        public Recipe(Item[] items, int[] itemCounts)
        {
            Ingredients = items;
            IngredientCounts = itemCounts;
        }
    }
}
