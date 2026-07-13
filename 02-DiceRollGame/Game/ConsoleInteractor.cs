namespace DiceRollGame.Game
{
    public class ConsoleInteractor : IUserInteractor
    {
        public int ReadIntegar(string message)
        {
            int result;
            do
            {
                Console.WriteLine(message);
            }while(!int.TryParse(Console.ReadLine(), out result));
            return result;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}