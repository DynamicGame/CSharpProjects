using _03_CookieCookbook.Ingredients;

public class RecipesUserInteractor : IRecipesUserInterator
{
    private readonly IUserInteractor _userInteractor;
    private readonly IIngredientFactory _ingredientFactory;
    private readonly IRecipesRepository _recipesRepository;
    public RecipesUserInteractor(IUserInteractor userInteractor, IIngredientFactory ingredientFactory, IRecipesRepository recipesRepository)
    {
        _userInteractor = userInteractor;
        _ingredientFactory = ingredientFactory;
        _recipesRepository = recipesRepository;
    }
    public void PrintExistingRecipes(IEnumerable<Recipe> recipes)
    {
        if(recipes.Count() == 0)
        {
            return;
        }
        PrintRecipes(recipes);
    }

    private void PrintRecipes(IEnumerable<Recipe> savedRecipes)
    {
        _userInteractor.WriteLine("Existing recipes are: ");
        var currentIndex = 1;
        
        foreach (var savedRecipe in savedRecipes)
        {
            _userInteractor.WriteLine($"******{currentIndex}*******");
            foreach (var ingredient in savedRecipe.Ingredients!)
            {
                
                _userInteractor.WriteLine(PrintIngredientByID(ingredient.ID));
            }
            currentIndex++;
        }
    }

    private string PrintIngredientByID(int id)
    {
        var ingredient = _ingredientFactory.GetByID(id);
        return $"{ingredient.Name}. {ingredient.InstructionOfPreparing}";
    }

    public void PrompUserForRecipes()
    {
        _userInteractor.WriteLine("Create a new cookie recipe! Available ingredients are: ");
        _ingredientFactory.PrintAvailableIngredients();
        
    }

    private List<Ingredient> UserSelectIngredients()
    {
        var exit = false;
        var ingredients = new List<Ingredient>();
        while (exit is false)
        {
            _userInteractor.WriteLine("Add an ingredient by its ID or type anything else if finished. ");
            var userInput = _userInteractor.ReadLine();
            var isNumber = int.TryParse(userInput, out var Id);
            if(isNumber is false)
            {
                exit = true;

            }
            else
            {
                var ingredient = _ingredientFactory.GetByID(Id);
                if (ingredient is null)
                {
                    continue;
                }
                ingredients.Add(ingredient);
            }
           
        }
        return ingredients;
        
    }


    public void ShowExitMessage()
    {
        _userInteractor.WriteLine("Press any key exit.");
        Console.ReadKey();
    }

    public List<Ingredient>? GetUserSelectedIngredients()
    {
        var ingredients = new List<Ingredient>();
        ingredients = UserSelectIngredients();
        return ingredients;
    }

    public void AddRecipe(string path, List<Recipe>? selectedIngredient)
    {
        _recipesRepository.SaveRecipe(path, selectedIngredient!);
    }

    public void PrintSingleRecipe(List<Ingredient>? selectedIngredientId)
    {
        foreach(var ingredientId in selectedIngredientId!)
        {
            _userInteractor.WriteLine(PrintIngredientByID(ingredientId.ID));
        }
    }

 
}
