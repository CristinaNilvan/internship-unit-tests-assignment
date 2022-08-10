using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure.InMemoryRepositories
{
    public class InMemoryIngredientRepository : IIngredientRepository
    {
        private List<Ingredient> _ingredients = new List<Ingredient>(PopulateLists.PopulateIngredients());

        public async Task CreateIngredient(Ingredient ingredient)
        {
            ingredient.Id = _ingredients.Count > 0 ? _ingredients.ElementAt(_ingredients.Count - 1).Id + 1 : 1;
            _ingredients.Add(ingredient);
        }

        public async Task DeleteIngredient(int ingredientId)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            _ingredients.Remove(ingredient);
        }

        public async Task<Ingredient> GetIngredientById(int ingredientId)
        {
            return _ingredients.FirstOrDefault(x => x.Id == ingredientId);
        }

        public async Task<Ingredient> GetIngredientByName(string ingredientName)
        {
            return _ingredients.FirstOrDefault(x => x.Name == ingredientName);
        }

        public async Task<List<Ingredient>> GetAllIngredients()
        {
            return _ingredients;
        }

        public async Task<List<Ingredient>> GetIngredientsByApprovedStatus(bool isApproved)
        {
            return _ingredients.Where(x => x.Approved == isApproved).ToList();
        }

        public async Task UpdateIngredient(int ingredientId, Ingredient newIngredient)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            var index = _ingredients.IndexOf(ingredient);
            newIngredient.Id = ingredientId;
            _ingredients[index] = newIngredient;
        }

        public async Task UpdateIngredientStatus(int ingredientId, bool status)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            ingredient.Approved = status;
        }
    }
}
