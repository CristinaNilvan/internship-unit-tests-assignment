using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure
{
    internal class PopulateLists
    {
        public static List<Ingredient> PopulateIngredients()
        {
            return new List<Ingredient>()
            {
                new Ingredient(1, "ing1", IngredientCategory.Fruit, 30, 15, 20, 15),
                new Ingredient(2, "ing2", IngredientCategory.Meat, 30, 15, 20, 15),
                new Ingredient(3, "ing3", IngredientCategory.Fruit, 30, 15, 20, 15),
                new Ingredient(4, "ing4", IngredientCategory.Meat,30, 15, 20, 15),
                new Ingredient(5, "ing5", IngredientCategory.Vegetable, 30, 15, 20, 15),
                new Ingredient(6, "ing6", IngredientCategory.Others, 30, 15, 20, 15),
                new Ingredient(7, "ing7", IngredientCategory.Dairy, 30, 15, 20, 15),
                new Ingredient(8, "ing8", IngredientCategory.Herbs, 30, 15, 20, 15),
                new Ingredient(9, "ing9", IngredientCategory.Vegetable, 30, 15, 20, 15),
                new Ingredient(10, "ing10", IngredientCategory.Dairy, 30, 15, 20, 15)
            };
        }

        public static List<Recipe> PopulateRecipes()
        {
            return new List<Recipe>()
            {
                new Recipe(1, "rec1", "auth1", "desc1", MealType.Normal, ServingTime.Breakfast, PopulateIngredients(), 560),
                new Recipe(2, "rec2", "auth2", "desc2", MealType.Normal, ServingTime.Breakfast, PopulateIngredients(), 490),
                new Recipe(3, "rec3", "auth3", "desc3", MealType.Normal, ServingTime.Breakfast, PopulateIngredients(), 350),
                new Recipe(4, "rec4", "auth4", "desc4", MealType.Normal, ServingTime.Lunch, PopulateIngredients(), 600),
                new Recipe(5, "rec5", "auth5", "desc5", MealType.Normal, ServingTime.Lunch, PopulateIngredients(), 370),
                new Recipe(6, "rec6", "auth6", "desc6", MealType.Normal, ServingTime.Lunch, PopulateIngredients(), 500),
                new Recipe(7, "rec7", "auth7", "desc7", MealType.Normal, ServingTime.Dinner, PopulateIngredients(), 600),
                new Recipe(8, "rec8", "auth8", "desc8", MealType.Normal, ServingTime.Dinner, PopulateIngredients(), 380),
                new Recipe(9, "rec9", "auth9", "desc9", MealType.Normal, ServingTime.Dinner, PopulateIngredients(), 580),
                new Recipe(10, "rec10", "auth10", "desc10", MealType.Normal, ServingTime.Dinner, PopulateIngredients(), 420),
            };
        }
    }
}
