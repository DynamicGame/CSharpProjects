



namespace DiceRollGame.Game;

public class Random : IRandom
{
    public int Next(int min, int max)
    {
        var random = new System.Random();
        int rollValue = random.Next(min, max);
        return rollValue;
    }
}