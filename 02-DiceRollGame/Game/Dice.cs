
namespace DiceRollGame.Game;

public class Dice : IDice
{
    private readonly IRandom _random;
    public const int Sides = 6;

    public Dice(IRandom random)
    {
        _random = random;
    }
    public int Roll()
    {
        int sides = Sides;
        return _random.Next(1, sides + 1);
    }
}
