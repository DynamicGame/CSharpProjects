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

    public IEnumerable<Recipe>? GetSavedRecipes(string path)
    {
        var savedIngredientsId = _stringsRepository.GetAll(path);
        if (savedIngredientsId is null)
        {
            return new List<Recipe>();
        }

        var ids = GetIdFromSaves(savedIngredientsId);

        return ids;
    }

    private List<Recipe> GetIdFromSaves(IEnumerable<string> savedIngredientsId)
    {
        
        var recipes = new List<Recipe>();
        foreach (var ingredientsId in savedIngredientsId)
        {
            var ingredient = new List<Ingredient>();
            foreach (var singleRecipe in ingredientsId)
            {
                if(singleRecipe != ',')
                {
                    ingredient.Add(_ingredientFactory.GetByID(int.Parse(singleRecipe.ToString())));
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