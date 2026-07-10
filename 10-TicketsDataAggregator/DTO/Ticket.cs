namespace _10_TicketsDataAggregator.DTO
{
    public class Ticket
    {
        public IReadOnlyList<string> Title { get; }
        public IReadOnlyList<DateOnly> Date { get; }
        public IReadOnlyList<TimeOnly> Time { get; }

        public Ticket(IReadOnlyList<string> title, IReadOnlyList<DateOnly> date, IReadOnlyList<TimeOnly> time)
        {
            Title = title;
            Date = date;
            Time = time;
        }
    }
}