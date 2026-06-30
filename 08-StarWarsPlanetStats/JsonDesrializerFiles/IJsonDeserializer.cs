namespace _08_StarWarsPlanetStats.JsonDesrializerFiles
{
    public interface IJsonDeserializer
    {
       T Deserialize<T>(string planetsData);
    }
}
