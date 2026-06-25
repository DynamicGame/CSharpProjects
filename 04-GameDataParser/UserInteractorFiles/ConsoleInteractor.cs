
namespace _04_GameDataParser.UserInteractorFiles;

public class ConsoleInteractor : IUserInteractor
{
    public string ReadLine()
    {
        return Console.ReadLine()!;
    }

    public string ReadValidFilePath()
    {

        var isFileNameValid = false;
        var userInputedFileName = "";
        do
        {
            userInputedFileName = Console.ReadLine();
            if (userInputedFileName is null)
            {
                Console.WriteLine("File name cannot be null");
            }
            else if (string.IsNullOrWhiteSpace(userInputedFileName))
            {
                Console.WriteLine("File name cannot be empty");
            }
            else if (!File.Exists(userInputedFileName))
            {
                Console.WriteLine("File not found");
            }
            else
            {
                isFileNameValid = true;
            }

        } while (!isFileNameValid);
        return userInputedFileName!;

    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}