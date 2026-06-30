namespace _08_StarWarsPlanetStats.ApiReaderFiles;
public class ApiReader : IApiReader
{
    public async Task<string> Read(string baseAddress, string responseUri)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);
        var response = await client.GetAsync(responseUri);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
