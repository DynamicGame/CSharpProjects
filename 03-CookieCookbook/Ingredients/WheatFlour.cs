namespace _03_CookieCookbook.Ingredients;
    public class WheatFlour : Flour
{
    public override int ID => 1;
    public override string Name => "Wheat Flour";

    public override string InstructionOfPreparing => $"Sieve. {base.InstructionOfPreparing}";
}
