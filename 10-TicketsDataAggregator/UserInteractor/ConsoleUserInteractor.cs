namespace _10_TicketsDataAggregator.UserInteractor
{
    internal class ConsoleUserInteractor : IUserInteractor
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
