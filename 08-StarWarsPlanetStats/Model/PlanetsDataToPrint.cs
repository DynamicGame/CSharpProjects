namespace _08_StarWarsPlanetStats.Model;

public class PlanetsDataToPrint
{
    public string Name { get; init; }
    public int? Diameter { get; init; }
    public int? SurfaceWater { get; init; }
    public int? Population { get; init; }
    public PlanetsDataToPrint(string name, int? diameter, int? surfaceWater, int? population)
    {
        Name = name;
        Diameter = diameter;
        SurfaceWater = surfaceWater;
        Population = population; 
    }

}