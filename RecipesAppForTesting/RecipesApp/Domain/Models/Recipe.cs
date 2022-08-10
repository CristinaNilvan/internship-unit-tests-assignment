using RecipesApp.Domain.Enums;

namespace RecipesApp.Domain.Models
{
    public class Recipe
    {
        //?
        public Recipe(int id, string name, string author, string description, MealType mealType, ServingTime servingTime,
            int calories, float fats, float carbs, float proteins, List<Ingredient> ingredients)
        {
            Id = id;
            Name = name;
            Author = author;
            Description = description;
            MealType = mealType;
            ServingTime = servingTime;
            Calories = calories;
            Fats = fats;
            Carbs = carbs;
            Proteins = proteins;
            Ingredients = new List<Ingredient>(ingredients);
            Approved = false;
        }

        //for dummy data
        public Recipe(int id, string name, string author, string description, MealType mealType, ServingTime servingTime,
            List<Ingredient> ingredients, int calories)
        {
            Id = id;
            Name = name;
            Author = author;
            Description = description;
            MealType = mealType;
            ServingTime = servingTime;
            Calories = calories;
            Ingredients = new List<Ingredient>(ingredients);
            Approved = true;
        }

        public Recipe(int id, string name, string author, string description, MealType mealType, ServingTime servingTime,
            List<Ingredient> ingredients)
        {
            Id = id;
            Name = name;
            Author = author;
            Description = description;
            MealType = mealType;
            ServingTime = servingTime;
            Ingredients = new List<Ingredient>(ingredients);
            CalculateNutritionalValuesForRecipe();
            Approved = false;
        }

        public Recipe(string name, string author, string description, MealType mealType, ServingTime servingTime,
            List<Ingredient> ingredients)
        {
            Name = name;
            Author = author;
            Description = description;
            MealType = mealType;
            ServingTime = servingTime;
            Ingredients = new List<Ingredient>(ingredients);
            CalculateNutritionalValuesForRecipe();
            Approved = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public MealType MealType { get; set; }
        public ServingTime ServingTime { get; set; }
        public int Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public bool Approved { get; set; } = false;

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            Calories += ingredient.Calories;
            Fats += ingredient.Fats;
            Carbs += ingredient.Carbs;
            Proteins += ingredient.Proteins;
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            Ingredients.Remove(ingredient);
            Calories -= ingredient.Calories;
            Fats -= ingredient.Fats;
            Carbs -= ingredient.Carbs;
            Proteins -= ingredient.Proteins;
        }

        public override string ToString()
        {
            return $"Id : {Id}; Name : {Name}; Type : {MealType}-{ServingTime}; Calories : {Calories}";
        }

        public override bool Equals(object obj)
        {
            return obj is Recipe recipe &&
                   Id == recipe.Id &&
                   Name == recipe.Name &&
                   Author == recipe.Author &&
                   Description == recipe.Description &&
                   MealType == recipe.MealType &&
                   ServingTime == recipe.ServingTime &&
                   Calories == recipe.Calories &&
                   Fats == recipe.Fats &&
                   Carbs == recipe.Carbs &&
                   Proteins == recipe.Proteins &&
                   EqualityComparer<List<Ingredient>?>.Default.Equals(Ingredients, recipe.Ingredients);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(Author);
            hash.Add(Description);
            hash.Add(MealType);
            hash.Add(ServingTime);
            hash.Add(Calories);
            hash.Add(Fats);
            hash.Add(Carbs);
            hash.Add(Proteins);
            hash.Add(Ingredients);
            return hash.ToHashCode();
        }

        private void CalculateNutritionalValuesForRecipe()
        {
            foreach (var ingredient in Ingredients)
            {
                Calories += ingredient.Calories;
                Fats += ingredient.Fats;
                Carbs += ingredient.Carbs;
                Proteins += ingredient.Proteins;
            }
        }
    }
}
