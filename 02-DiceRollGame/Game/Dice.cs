public class Dice
{
    private readonly Random _random ;
    public const int Sides = 6;

    public Dice(Random random)
    {
        _random = random;
    }
    public int Roll()
    {
        int sides = Sides;
        return _random.Next(1, sides + 1);
    }
}