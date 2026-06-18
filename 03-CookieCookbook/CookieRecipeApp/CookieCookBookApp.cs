using _03_CookieCookbook.Ingredients;

public class CookieCookBookApp
{
    private readonly string _path;
    private readonly IRecipesUserInterator _recipesUserInteractor;
    public CookieCookBookApp(string path, IRecipesUserInterator recipesManager)
    {
        _recipesUserInteractor = recipesManager;
        _path = path;
    }
    public void Run()
    {
        _recipesUserInteractor.PrintExistingRecipes(_path);
        _recipesUserInteractor.PrompUserForRecipes();
        _recipesUserInteractor.ShowExitMessage();
    }

}


public class RecipesUserInteractor : IRecipesUserInterator
{
    private readonly IUserInteractor _userInteractor;
    private readonly IIngredientFactory _ingredientFactory;
    private readonly IStringsRepository _stringRepository;
    public RecipesUserInteractor(IUserInteractor userInteractor, IIngredientFactory ingredientFactory, IStringsRepository stringRepository)
    {
        _userInteractor = userInteractor;
        _ingredientFactory = ingredientFactory;
        _stringRepository = stringRepository;
    }
    public void PrintExistingRecipes(string path)
    {
        
    }

    public void PrompUserForRecipes()
    {
        throw new NotImplementedException();
    }

    public void ShowExitMessage()
    {
        throw new NotImplementedException();
    }
}