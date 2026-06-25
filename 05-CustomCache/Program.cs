
//IDataDownloader dataDownloader = new SlowDataDownloader();
IDataDownloader dataDownloader = new CacheDataDownloaded(new SlowDataDownloader()) ;

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

Console.ReadKey();

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        //let's imagine this method downloads real data,
        //and it does it slowly
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}


public class Cache <TKey, TData>
{
    private readonly Dictionary<TKey, TData> _cachedDatas;

    public Cache()
    {
        _cachedDatas = new Dictionary<TKey, TData>();
    }
    public TData Get(TKey resourceId, Func<TKey, TData> getForFirstTime) 
    {
        
        if (!_cachedDatas.ContainsKey(resourceId))
        {
            
                _cachedDatas[resourceId] = getForFirstTime(resourceId);
        }
      
            return _cachedDatas[resourceId];
        
    }
}


public class CacheDataDownloaded : IDataDownloader
{
    private readonly Cache<string, string> _cache = new Cache<string, string>();
    private readonly IDataDownloader _dataDownloader;
    public CacheDataDownloaded(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }
    public string DownloadData(string resourceId)
    {
        return _cache.Get(resourceId, _dataDownloader.DownloadData);
    }
}