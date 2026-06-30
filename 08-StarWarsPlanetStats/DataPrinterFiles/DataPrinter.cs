using _08_StarWarsPlanetStats.ApplicationInteractor;

namespace _08_StarWarsPlanetStats.DataPrinterFiles
{
    public class DataPrinter : IDataPrinter
    {
        private readonly IAppInteractor _appInteractor;
        public DataPrinter(IAppInteractor appInteractor)
        {
            _appInteractor = appInteractor;
        }
        public void Print<TSource>(List<TSource> datas)
        {
            int index = 0;
            foreach (var data in datas)
            {

                var properties = data!.GetType()
                    .GetProperties().Where(p => p.Name != "EqualityContract").ToList();
                if (index == 0)
                {
                    for (int i = 0; i < properties.Count(); i++)
                    {
                        if (i == 0)
                        {
                            _appInteractor.Write($"{properties[i].Name,-15}");
                        }
                        else
                        {
                            _appInteractor.Write($"{properties[i].Name,15}");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < properties.Count(); i++)
                    {
                        if (i == 0)
                        {
                            _appInteractor.Write($"{properties[i].GetValue(data),-15}");
                        }
                        else
                        {
                            _appInteractor.Write($"{properties[i].GetValue(data),15}");
                        }
                    }
                }

                _appInteractor.WriteLine();
                index++;
            }
        }
    }
}