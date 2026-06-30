namespace _08_StarWarsPlanetStats.DataPrinterFiles
{
    public interface IDataPrinter
    {

        void Print<TSource>(List<TSource> planets);
    }
}
