using _10_TicketsDataAggregator.DTO;

namespace _10_TicketsDataAggregator.FileWriter
{
    internal interface IFileWriter
    {
        void WriteToFile(string folderPath, IEnumerable<Ticket> ticketsData);
    }
}