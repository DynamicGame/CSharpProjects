using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;

namespace CsvDataAccess.NewSolution;

public class TableData : ITableData
{
    private readonly List<FastRow> _rows;
    public int RowCount => _rows.Count;
    public IEnumerable<string> Columns { get; }

    public TableData(IEnumerable<string> columns, List<FastRow> rows)
    {
        _rows = rows;
        Columns = columns;
    }

    public object GetValue(string columnName, int rowIndex)
    {
        return _rows[rowIndex].GetAtColumn(columnName);
    }
}