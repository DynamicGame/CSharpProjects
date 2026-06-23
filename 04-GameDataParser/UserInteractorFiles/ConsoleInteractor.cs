
namespace _04_GameDataParser.UserInteractorFiles;

public class ConsoleInteractor : IUserInteractor
{
    public string ReadLine()
    {
        return Console.ReadLine()!;
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}