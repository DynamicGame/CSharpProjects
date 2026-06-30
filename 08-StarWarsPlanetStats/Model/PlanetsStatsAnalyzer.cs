using _08_StarWarsPlanetStats.ApplicationInteractor;

namespace _08_StarWarsPlanetStats.Model;

public class PlanetsStatsAnalyzer : IPlanetsStatsAnalyzer
{
    private readonly IAppInteractor _appInteractor;
    public PlanetsStatsAnalyzer(IAppInteractor interactor)
    {
        _appInteractor = interactor;
    }
    public void Run(IEnumerable<PlanetsDataToPrint> planetsData)
    {
       
        string? userInput = null;
        bool exit = false;
        do
        {
            _appInteractor.WriteLine(@$"The statistics of which proprty would you like to see?
population
diameter
surface water");
            userInput = _appInteractor.ReadLine();
            if ( IsUserInputCorrectProperty(userInput))
            {
                exit = true;
            }
        } while (!exit);

        PrintData(userInput, planetsData);
    }

    private void PrintData(string userInput, IEnumerable<PlanetsDataToPrint> planetsData)
    {
        switch (userInput.ToLower())
        {
            case "population":
                _appInteractor.WriteLine($"Max {userInput} is {planetsData.Where(planet => planet.Population != null).Max(planet => planet.Population)}");
                _appInteractor.WriteLine($"Min {userInput} is {planetsData.Where(planet => planet.Population != null).Min(planet => planet.Population)}");
                return;
            case "diameter":
                _appInteractor.WriteLine($"Max {userInput} is {planetsData.Where(planet => planet.Diameter != null).Max(planet => planet.Diameter)}");
                _appInteractor.WriteLine($"Min {userInput} is {planetsData.Where(planet => planet.Diameter != null).Min(planet => planet.Diameter)}");
                return;
            case "surface water":
                _appInteractor.WriteLine($"Max {userInput} is {planetsData.Where(planet => planet.SurfaceWater != null).Max(planet => planet.SurfaceWater)}");
                _appInteractor.WriteLine($"Min {userInput} is {planetsData.Where(planet => planet.SurfaceWater != null).Min(planet => planet.SurfaceWater)}");
                return;
        }
        
    }

 
    private bool IsUserInputCorrectProperty(string userInput)
    {
        if(userInput?.ToUpper() == "POPULATION")
        {
            return true;
        }else if(userInput?.ToUpper() == "DIAMETER")
        {
            return true;
        }else if (userInput?.ToUpper() == "SURFACE WATER")
        {
            return true;
        }
        else
        {
            return false;
        }
       
    }
}