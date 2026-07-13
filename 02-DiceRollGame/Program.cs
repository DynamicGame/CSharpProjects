using DiceRollGame.Game;
using Random = DiceRollGame.Game.Random;

var consoleInteractor = new ConsoleInteractor();
var diceGame = new DiceGame(new Dice(new Random()), consoleInteractor);
var gameResult = diceGame.Play();
diceGame.PrintResult(gameResult);





Console.ReadKey();
