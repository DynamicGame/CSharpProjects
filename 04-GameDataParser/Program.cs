
using _04_GameDataParser.App;
using _04_GameDataParser.LoggerFiles;
using _04_GameDataParser.UserInteractorFiles;

try
{
    var userInteractor = new ConsoleInteractor();
    var gameDataPrinter = new GameDataPrinter(userInteractor);
    var dataRepository = new DataRepository();
    var logger = new Logger(dataRepository);
    var jsonDeserializer = new JsonDeserializer(userInteractor, logger);
    var gameDataReposiotry = new GameDataReader(dataRepository, jsonDeserializer);


    var gameDataParserApp = new GameDataParser(userInteractor, gameDataReposiotry, gameDataPrinter);

    gameDataParserApp.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");


}

Console.WriteLine("Press any key to close.");

Console.ReadKey();
