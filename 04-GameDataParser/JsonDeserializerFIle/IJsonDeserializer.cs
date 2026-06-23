public interface IJsonDeserializer
{
    T Deserialize<T>(string data);
}