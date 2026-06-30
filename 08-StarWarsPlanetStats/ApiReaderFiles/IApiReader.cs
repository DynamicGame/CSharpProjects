namespace _08_StarWarsPlanetStats.ApiReaderFiles;

public interface IApiReader
{
    Task<string> Read(string baseAddress, string responseUri);
}