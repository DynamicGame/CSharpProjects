using _03_CookieCookbook.Ingredients;

public class RecipesRepository : IRecipesRepository
{


    private readonly StringsRepository _stringsRepository;
    private readonly IIngredientFactory _ingredientFactory;

    public RecipesRepository(StringsRepository stringsRepository, IIngredientFactory ingredientFactory)
    {
        _stringsRepository = stringsRepository;
        _ingredientFactory = ingredientFactory;
    }

    public IEnumerable<Recipe> GetSavedRecipes(string path)
    {
        var savedIngredientsId = _stringsRepository.GetAll(path);
        if (savedIngredientsId.Count() == 0)
        {
            return new List<Recipe>();
        }

        var recipes = GetRecipesFromSaveID(savedIngredientsId);

        return recipes;
    }

    private List<Recipe> GetRecipesFromSaveID(IEnumerable<string> savedIngredientsId)
    {
        
        var recipes = new List<Recipe>();
        foreach (var singleRecipeIds in savedIngredientsId)
        {
            var ingredient = new List<Ingredient>();
            foreach (var singleRecipeId in singleRecipeIds)
            {
                if(singleRecipeId != ',')
                {
                    ingredient.Add(_ingredientFactory.GetByID(int.Parse(singleRecipeId.ToString())));
                }
            }
            var recipe = new Recipe();
            recipe.Ingredients = ingredient;
            recipes.Add(recipe);
        }
        return recipes;
    }



   


    public void SaveRecipe(string path, List<Recipe> selectedIngredients)
    {
        var selectedIngredientsId = GetIngredientsID(selectedIngredients);
        _stringsRepository.Save(path, selectedIngredientsId);
    }

    private IEnumerable<string> GetIngredientsID(List<Recipe> selectedIngredients)
    {
        var result = new List<string>();
        string ids ="";
     
        foreach (var recipe in selectedIngredients)
        {
            var ingredientsId = new List<string>();
            foreach (var ingredient in recipe.Ingredients!)
            {
               
                ingredientsId.Add(ingredient.ID.ToString());
                
            }
            ids = string.Join(",", ingredientsId);
            result.Add(ids);
        }
        
       
        return result;

    }
}