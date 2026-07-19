namespace _12_PasswordGenerator.RandomNumberGenerator;

public interface IRandom
{
    int Next(int min, int max);
    int Next(int min);
}