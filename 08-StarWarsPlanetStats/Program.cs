
using _08_StarWarsPlanetStats;
using System.Text.Json;

var baseAddress = $"https://swapi.info/api/";
var responseURI = $"planets";
var apiReader = new ApiReader();
var jsonDeserializer = new JsonDeserializer();
var consoleInteractor = new ConsoleInteractor();
var dataPrinter = new DataPrinter(consoleInteractor);
var planetStatAnalyzer = new PlanetsStatsAnalyzer(consoleInteractor);
var app = new StarWarsPlanetApp(apiReader,jsonDeserializer,dataPrinter, planetStatAnalyzer);

await app.Run(baseAddress, responseURI);

Console.ReadKey();

