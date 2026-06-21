using _03_CookieCookbook.Ingredients;

public interface IRecipesUserInterator
{
    void AddRecipe(string path, List<Recipe>? selectedIngredientId);
    List<Ingredient>? GetUserSelectedIngredients();
    void PrintExistingRecipes(IEnumerable<Recipe> recipes);
    void PrintSingleRecipe(List<Ingredient>? selectedIngredient);
    void PrompUserForRecipes();
    void ShowExitMessage();
}