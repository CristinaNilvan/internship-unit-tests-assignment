using RecipesApp.Domain.Enums;

namespace RecipesApp.Domain.Models
{
    public class Ingredient
    {
        //for dummy data
        public Ingredient(int id, string name, IngredientCategory category, int calories, float fats, float carbs, float proteins)
        {
            Id = id;
            Name = name;
            Category = category;
            Calories = calories;
            Fats = fats;
            Carbs = carbs;
            Proteins = proteins;
            Approved = true;
        }

        public Ingredient(string name, IngredientCategory category, int calories, float fats, float carbs, float proteins)
        {
            Name = name;
            Category = category;
            Calories = calories;
            Fats = fats;
            Carbs = carbs;
            Proteins = proteins;
            Approved = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IngredientCategory Category { get; set; }
        public int Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
        public float Quantity { get; set; }
        public bool Approved { get; set; } = false;

        public override string ToString()
        {
            return $"Id : {Id}; Name : {Name}; Category : {Category}; Calories : {Calories}";
        }

        public override bool Equals(object obj)
        {
            return obj is Ingredient ingredient &&
                   Id == ingredient.Id &&
                   Name == ingredient.Name &&
                   Category == ingredient.Category &&
                   Calories == ingredient.Calories &&
                   Fats == ingredient.Fats &&
                   Carbs == ingredient.Carbs &&
                   Proteins == ingredient.Proteins;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Category, Calories, Fats, Carbs, Proteins);
        }
    }
}
