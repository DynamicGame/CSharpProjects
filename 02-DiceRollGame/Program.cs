var diceGame = new DiceGame(new Dice(new Random()));
var gameResult = diceGame.Play();
diceGame.PrintResult(gameResult);





Console.ReadKey();
