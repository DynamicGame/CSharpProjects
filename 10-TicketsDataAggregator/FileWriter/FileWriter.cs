using _10_TicketsDataAggregator.DTO;

namespace _10_TicketsDataAggregator.FileWriter
{
    internal class FileWriter : IFileWriter
    {
        public void WriteToFile(string filePath, IEnumerable<Ticket> ticketsData)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var ticket in ticketsData)
                {
                    writer.WriteLine($"Title: {string.Join(", ", ticket.Title)}");
                    writer.WriteLine($"Date: {string.Join(", ", ticket.Date)}");
                    writer.WriteLine($"Time: {string.Join(", ", ticket.Time)}");
                    writer.WriteLine(new string('-', 20));
                }
            }
        }
    }
}