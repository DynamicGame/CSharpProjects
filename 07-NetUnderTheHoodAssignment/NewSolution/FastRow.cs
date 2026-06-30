namespace CsvDataAccess.NewSolution;

public class FastRow 
{
    private Dictionary<string, int> _intsData;
    private Dictionary<string, decimal> _decimalsData;
    private Dictionary<string, string> _stringsData;
    private Dictionary<string, bool> _boolsData;
    
    public FastRow()
    {
        _intsData = new();
        _decimalsData = new();
        _stringsData = new();
        _boolsData = new();
    }

    public void AssignCell(string column, bool data)
    {
        _boolsData[column] = data;
    }
    public void AssignCell(string column, int data)
    {
        _intsData[column] = data;
    }
    public void AssignCell(string column, decimal data)
    {
        _decimalsData[column] = data;
    }
    public void AssignCell(string column, string data)
    {
        _stringsData[column] = data;
    }

    public object GetAtColumn(string columnName)
    {
        if (_intsData.ContainsKey(columnName))
        {
            return _intsData[columnName];
        }
        else if (_decimalsData.ContainsKey(columnName))
        {
            return _decimalsData[columnName];
        }
        else if (_stringsData.ContainsKey(columnName))
        {
            return _stringsData[columnName];
        }else if (_boolsData.ContainsKey(columnName))
        {
            return _boolsData[columnName];
        }
        return null;
    }

    


}
