namespace _08_StarWarsPlanetStats.ApplicationInteractor;

public class ConsoleInteractor : IAppInteractor
{
    public string ReadLine()
    {
        return Console.ReadLine()!;
    }

    public void Write(string message)
    {
        Console.Write(message);
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public void WriteLine()
    {
        Console.WriteLine();
    }
}