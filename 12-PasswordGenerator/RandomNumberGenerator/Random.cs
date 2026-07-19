namespace _12_PasswordGenerator.RandomNumberGenerator;

public class Random : IRandom
{
    public int Next(int minValue, int maxValue)
    {
        
        return new System.Random().Next(minValue, maxValue);
    }

    public int Next(int maxValue)
    {
        return new System.Random().Next(maxValue);
    }
}