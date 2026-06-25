using CookieCookbook.DataAccess;
using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipesRepository(
        IStringsRepository stringsRepository,
        IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> Read(string filePath)
    {
        List<string> recipesFromFile = _stringsRepository.Read(filePath);
        return recipesFromFile.Select(recipeFromFile => RecipeFromString(recipeFromFile)).ToList();
        
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textualIds = recipeFromFile.Split(Separator);
     
        var ingredients = textualIds.Select(textualId => int.Parse(textualId))
            .Select(id => _ingredientsRegister.GetById(id));

        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {

        var recipesAsStrings = allRecipes.Select(recipe => string.Join(Separator, recipe.Ingredients.Select(x => x.Id))).ToList();

        _stringsRepository.Write(filePath, recipesAsStrings);
    }
}
