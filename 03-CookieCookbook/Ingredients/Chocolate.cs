namespace _03_CookieCookbook.Ingredients;

public class Chocolate : Ingredient
{
    public override int ID => 4;
    public override string Name => "Chocolate";
    public override string InstructionOfPreparing => $"Melt in a water bath. {base.InstructionOfPreparing}";
}
