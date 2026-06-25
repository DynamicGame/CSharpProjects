namespace CookieCookbook.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id)
    {
       var ingredientWithIdEqualToSearch = All.Where(ingredient => ingredient.Id == id);
        if(ingredientWithIdEqualToSearch.Count() > 1)
        {
            throw new InvalidOperationException("Can't have ingredient with same ID in the project");
        }
        return All.FirstOrDefault(ingredient => ingredient.Id == id)!;
    }
}

