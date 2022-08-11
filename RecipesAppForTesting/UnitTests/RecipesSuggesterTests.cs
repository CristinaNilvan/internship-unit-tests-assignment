using Moq;
using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Logic;
using RecipesApp.Domain.Models;

namespace UnitTests
{
    public class RecipesSuggesterTests : IClassFixture<Fixture>
    {
        [Fact]
        public void SuggestRecipes_MatchesExist_ReturnsBestMatches()
        {
            // arrange
            var firstIngredient = new Ingredient(1, "ing1", IngredientCategory.Fruit, 30, 15, 20, 15)
            {
                Quantity = 200
            };

            var secondIngredient = new Ingredient(2, "ing2", IngredientCategory.Meat, 30, 15, 20, 15)
            {
                Quantity = 200
            };

            var firstIngredientList = new List<Ingredient>
            {
                firstIngredient
            };

            var secondIngredientList = new List<Ingredient>
            {
                secondIngredient
            };

            var recipes = new List<Recipe>()
            {
                new Recipe(1, "rec1", "auth1", "desc1", MealType.Normal, ServingTime.Breakfast, firstIngredientList, 560),
                new Recipe(2, "rec2", "auth2", "desc2", MealType.Normal, ServingTime.Breakfast, secondIngredientList, 490),
                new Recipe(3, "rec3", "auth3", "desc3", MealType.Normal, ServingTime.Breakfast, firstIngredientList, 350),
            };

            var mockRecipeRepository = new Mock<IRecipeRepository>();
            mockRecipeRepository
                .Setup(x => x.GetRecipesByApprovedStatus(It.IsAny<bool>()))
                .Returns(recipes);

            var recipesSuggester = new RecipesSuggester(mockRecipeRepository.Object);

            // act
            var suggestedRecipes = recipesSuggester.SuggestRecipes("ing1", 300);

            // assert
            Assert.Equal(2, suggestedRecipes.Count);
        }

        [Fact]
        public void SuggestRecipes_MatchesExist_ReturnsRecipesWithIngredient()
        {
            // arrange
            var firstIngredient = new Ingredient(1, "ing1", IngredientCategory.Fruit, 30, 15, 20, 15)
            {
                Quantity = 200
            };

            var secondIngredient = new Ingredient(2, "ing2", IngredientCategory.Meat, 30, 15, 20, 15)
            {
                Quantity = 200
            };

            var ingredientList = new List<Ingredient>
            {
                firstIngredient,
                secondIngredient
            };

            var recipes = new List<Recipe>()
            {
                new Recipe(1, "rec1", "auth1", "desc1", MealType.Normal, ServingTime.Breakfast, ingredientList, 560),
                new Recipe(2, "rec2", "auth2", "desc2", MealType.Normal, ServingTime.Breakfast, ingredientList, 490),
                new Recipe(3, "rec3", "auth3", "desc3", MealType.Normal, ServingTime.Breakfast, ingredientList, 350),
            };

            var mockRecipeRepository = new Mock<IRecipeRepository>();
            mockRecipeRepository
                .Setup(x => x.GetRecipesByApprovedStatus(It.IsAny<bool>()))
                .Returns(recipes);

            var recipesSuggester = new RecipesSuggester(mockRecipeRepository.Object);

            // act
            var suggestedRecipes = recipesSuggester.SuggestRecipes("ing1", 800);

            // assert
            Assert.Equal(3, suggestedRecipes.Count);
        }

        [Fact]
        public void SuggestRecipes_MatchesDontExist_ReturnsAllRecipes()
        {
            // arrange
            var firstIngredient = new Ingredient(1, "ing1", IngredientCategory.Fruit, 30, 15, 20, 15)
            {
                Quantity = 200
            };

            var secondIngredient = new Ingredient(2, "ing2", IngredientCategory.Meat, 30, 15, 20, 15)
            {
                Quantity = 200
            };

            var ingredientList = new List<Ingredient>
            {
                firstIngredient,
                secondIngredient
            };

            var recipes = new List<Recipe>()
            {
                new Recipe(1, "rec1", "auth1", "desc1", MealType.Normal, ServingTime.Breakfast, ingredientList, 560),
                new Recipe(2, "rec2", "auth2", "desc2", MealType.Normal, ServingTime.Breakfast, ingredientList, 490),
                new Recipe(3, "rec3", "auth3", "desc3", MealType.Normal, ServingTime.Breakfast, ingredientList, 350),
            };

            var mockRecipeRepository = new Mock<IRecipeRepository>();
            mockRecipeRepository
                .Setup(x => x.GetRecipesByApprovedStatus(It.IsAny<bool>()))
                .Returns(recipes);

            var recipesSuggester = new RecipesSuggester(mockRecipeRepository.Object);

            // act
            var suggestedRecipes = recipesSuggester.SuggestRecipes("ing3", 500);

            // assert
            Assert.Equal(3, suggestedRecipes.Count);
        }
    }
}