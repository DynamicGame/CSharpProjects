public class ConsoleUserInteractor : IUserInteractor
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
    public string ReadLine()
    {
        return Console.ReadLine()!;
    }
}