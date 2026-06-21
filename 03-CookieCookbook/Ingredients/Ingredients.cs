namespace _03_CookieCookbook.Ingredients;

public class Ingredients : IIngredientFactory
{
    private readonly List<Ingredient> _ingredients =
    [
        new WheatFlour(),
        new Butter(),
        new Sugar(),
        new Chocolate(),
        new CoconutFlour(),
        new CocoaPowder(),
        new Cardamom(),
        new Cinnamon()
    ];
    private readonly IUserInteractor _userInteractor;

    public Ingredients(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }
    public Ingredient GetByID(int id)
    {
        return _ingredients.FirstOrDefault(x => x.ID == id)!;
    }

    public IEnumerable<Ingredient> GetAllIngredients()
    {
        return _ingredients;
    }

    public void PrintAvailableIngredients()
    {
        _ingredients.Sort((x, y) => x.ID.CompareTo(y.ID));

        _ingredients.ForEach(ingredient => _userInteractor.WriteLine($"{ingredient.ID}. {ingredient.Name}"));
    }
}
