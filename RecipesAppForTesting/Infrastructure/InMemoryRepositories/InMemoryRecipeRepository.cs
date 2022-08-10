using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure.InMemoryRepositories
{
    public class InMemoryRecipeRepository : IRecipeRepository
    {
        private List<Recipe> _recipes = new List<Recipe>(PopulateLists.PopulateRecipes());

        public async Task CreateRecipe(Recipe recipe)
        {
            recipe.Id = _recipes.Count > 0 ? _recipes.ElementAt(_recipes.Count - 1).Id + 1 : 1;
            _recipes.Add(recipe);
        }

        public async Task DeleteRecipe(int recipeId)
        {
            var recipe = _recipes.FirstOrDefault(x => x.Id == recipeId);
            _recipes.Remove(recipe);
        }

        public async Task<Recipe> GetRecipeById(int recipeId)
        {
            return _recipes.FirstOrDefault(x => x.Id == recipeId);
        }

        public async Task<Recipe> GetRecipeByName(string recipeName)
        {
            return _recipes.FirstOrDefault(x => x.Name == recipeName);
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            return _recipes;
        }

        public async Task<List<Recipe>> GetRecipesByApprovedStatus(bool isApproved)
        {
            return _recipes.Where(x => x.Approved == isApproved).ToList();
        }

        public async Task<List<Recipe>> GetRecipesByIngredients(List<Ingredient> ingredients)
        {
            var approvedRecipes = GetRecipesByApprovedStatus(true).Result;
            var filteredRecipes = new List<Recipe>();

            foreach (var recipe in approvedRecipes)
            {
                var containsAll = CheckIfRecipeContainsAllIngredients(recipe.Ingredients, ingredients);

                if (containsAll)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes;
        }

        public async Task UpdateRecipe(int recipeId, Recipe newRecipe)
        {
            var recipe = _recipes.FirstOrDefault(x => x.Id == recipeId);
            var index = _recipes.IndexOf(recipe);
            newRecipe.Id = recipeId;
            _recipes[index] = newRecipe;
        }

        public async Task UpdateRecipeStatus(int recipeId, bool status)
        {
            var recipe = _recipes.FirstOrDefault(x => x.Id == recipeId);
            recipe.Approved = status;
        }

        private bool CheckIfRecipeContainsAllIngredients(List<Ingredient> recipeIngredientList, List<Ingredient> givenIngredientList)
        {
            return givenIngredientList.All(x => recipeIngredientList.Any(y => x.Id == y.Id));
        }
    }
}
