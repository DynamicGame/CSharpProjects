namespace _03_CookieCookbook.Ingredients;

public class CoconutFlour : Flour
{
    public override int ID => 2;
    public override string Name => "Coconut Flour";

    public override string InstructionOfPreparing => $"Sieve. {base.InstructionOfPreparing}";
}
