using _10_TicketsDataAggregator.DTO;

namespace _10_TicketsDataAggregator
{
    internal interface ITicketsDataReader
    {
         IEnumerable<Ticket> ReadTicketsData(IEnumerable<string> ticketPdfData);
    }
}