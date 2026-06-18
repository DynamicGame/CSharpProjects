namespace _03_CookieCookbook.Ingredients;

public abstract class Flour : Ingredient
{
    public override string InstructionOfPreparing => $"Sieve. {base.InstructionOfPreparing}";
}
