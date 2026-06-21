public class CookieCookBookApp
{
  
    private readonly IRecipesUserInterator _recipesUserInteractor;
    private readonly IRecipesRepository _recipesRepository;
    private readonly IUserInteractor _userInteractor;
    public CookieCookBookApp(IRecipesUserInterator recipesManager, IRecipesRepository recipesRepository, IUserInteractor userInteractor)
    {
        _recipesUserInteractor = recipesManager;
        _recipesRepository = recipesRepository;
        _userInteractor = userInteractor;
        
    }
    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.GetSavedRecipes(filePath).ToList();
        _recipesUserInteractor.PrintExistingRecipes(allRecipes!);
        _recipesUserInteractor.PrompUserForRecipes();
        var selectedIngredient = _recipesUserInteractor.GetUserSelectedIngredients();
       
        if (selectedIngredient!.Count == 0)
        {
            _userInteractor.WriteLine("No ingredients have been selected. Recipe will not be saved.");

        }
        else
        {
            _userInteractor.WriteLine("Recipe added:");
            _recipesUserInteractor.PrintSingleRecipe(selectedIngredient);
            var recipe = new Recipe();
            recipe.Ingredients = selectedIngredient;
            allRecipes.Add(recipe);
            _recipesRepository.SaveRecipe(filePath, allRecipes!);
            
        }
        _recipesUserInteractor.ShowExitMessage();
    }

}
