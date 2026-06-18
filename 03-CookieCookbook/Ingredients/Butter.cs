namespace _03_CookieCookbook.Ingredients;

public class Butter : Ingredient
{
    public override int ID => 3;
    public override string Name => "Butter";
    public override string InstructionOfPreparing => $"Melt on low heat. {base.InstructionOfPreparing}";
}
