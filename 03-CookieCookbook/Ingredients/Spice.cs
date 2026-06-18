namespace _03_CookieCookbook.Ingredients;

public abstract class Spice : Ingredient
{
    public override string InstructionOfPreparing => $"Take a half teaspoon. {base.InstructionOfPreparing}";
}
