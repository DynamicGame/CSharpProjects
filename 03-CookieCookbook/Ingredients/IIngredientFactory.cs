namespace _03_CookieCookbook.Ingredients;

public interface IIngredientFactory
{
    Ingredient GetByID(int id);
    IEnumerable<Ingredient> GetAllIngredients();

    void PrintAvailableIngredients();
}