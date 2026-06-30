using _08_StarWarsPlanetStats.ApiReaderFiles;
using _08_StarWarsPlanetStats.DataPrinterFiles;
using _08_StarWarsPlanetStats.DTOs;
using _08_StarWarsPlanetStats.JsonDesrializerFiles;
using _08_StarWarsPlanetStats.Model;

namespace _08_StarWarsPlanetStats.App;

public class StarWarsPlanetApp
{
    private readonly IApiReader _apiReader;
    private readonly IJsonDeserializer _jsonDeserializer;
    private readonly IDataPrinter _planetDataPrinter;
    private readonly IPlanetsStatsAnalyzer _planetsStats;
    public StarWarsPlanetApp(IApiReader apiReader, IJsonDeserializer jsonDeserializer, IDataPrinter dataPrinter, IPlanetsStatsAnalyzer planetsStats)
    {
        _apiReader = apiReader;
        _jsonDeserializer = jsonDeserializer;
        _planetDataPrinter = dataPrinter;
        _planetsStats = planetsStats;
    }

    public async Task Run(string baseAddress, string responseUri)
    {
        var planetsData = await _apiReader.Read(baseAddress, responseUri);
        var planets = _jsonDeserializer.Deserialize<List<Planet>>(planetsData);
        var dataToPrint = planets.Select(x =>
        {
            var name = x.name;
            int? diameterResult = !int.TryParse(x.diameter, out int diameter) ? null : diameter;
            int? surfaceWaterResult = !int.TryParse(x.surface_water, out int surfaceWater) ? null : surfaceWater;
            int? populationResult = !int.TryParse(x.population, out int population) ? null : population;

            return new PlanetsDataToPrint(name, diameterResult, surfaceWaterResult, populationResult);

        });
        _planetDataPrinter.Print<PlanetsDataToPrint>(dataToPrint.ToList());
        _planetsStats.Run(dataToPrint);

    }
}
