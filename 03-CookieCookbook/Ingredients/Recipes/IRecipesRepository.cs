using _03_CookieCookbook.Ingredients;

public interface IRecipesRepository
{
    IEnumerable<Recipe>? GetSavedRecipes(string path);
    void SaveRecipe(string path, List<Recipe> selectedIngredients);
}