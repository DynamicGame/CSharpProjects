using System.Text.Json;

namespace _08_StarWarsPlanetStats.JsonDesrializerFiles
{
    public class JsonDeserializer : IJsonDeserializer
    {
        public T Deserialize<T>(string planetsData)
        {
            return JsonSerializer.Deserialize<T>(planetsData)!;
        }
    }
}