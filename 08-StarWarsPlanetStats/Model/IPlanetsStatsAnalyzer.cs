namespace _08_StarWarsPlanetStats.Model;

public interface IPlanetsStatsAnalyzer
{
    void Run(IEnumerable<PlanetsDataToPrint> dataToPrint);
}
