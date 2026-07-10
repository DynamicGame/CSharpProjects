using _10_TicketsDataAggregator.DTO;

namespace _10_TicketsDataAggregator.TicketsReader
{
    internal class TicketsDataReader : ITicketsDataReader
    {
        public IEnumerable<Ticket> ReadTicketsData(IEnumerable<string> ticketPdfData)
        {
            var tickets = new List<Ticket>();
            foreach (var pdfText in ticketPdfData)
            {

                var ticketValues = pdfText.Split(new[] { "Title:", "Date:", "Time:", "Visit us:" }, StringSplitOptions.RemoveEmptyEntries);

                tickets.Add(GetTicketFromValues(ticketValues));
            }
            return tickets;
        }

        private Ticket GetTicketFromValues(string[] ticketValues)
        {
            var url = ticketValues[^1];
            var relenvantTicketDataOnly = ticketValues.Take(new Range(1, ticketValues.Length -1 ));
            var titles = GetTitles(relenvantTicketDataOnly);
            var dates = GetDates(relenvantTicketDataOnly);
            var times = GetTimes(relenvantTicketDataOnly);

            return new Ticket(titles, dates, times);
        }

       
        private IReadOnlyList<string> GetTitles(IEnumerable<string> relenvantTicketDataOnly)
        {
            var result = new List<string>();
            for (int i = 0; i < relenvantTicketDataOnly.Count(); i+=3)
            {
                result.Add(relenvantTicketDataOnly.ElementAt(i));
            }
            return result;
        }
        private IReadOnlyList<DateOnly> GetDates(IEnumerable<string> relenvantTicketDataOnly)
        {
            var result = new List<DateOnly>();
            for (int i = 1; i < relenvantTicketDataOnly.Count(); i += 3)
            {
                result.Add(DateOnly.Parse(relenvantTicketDataOnly.ElementAt(i)));
            }
            return result;
        }

        private IReadOnlyList<TimeOnly> GetTimes(IEnumerable<string> relenvantTicketDataOnly)
        {
            var result = new List<TimeOnly>();
            for (int i = 2; i < relenvantTicketDataOnly.Count(); i += 3)
            {
                result.Add(TimeOnly.Parse(relenvantTicketDataOnly.ElementAt(i)));
            }
            return result;
        }
    }
}