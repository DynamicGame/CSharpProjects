using _12_PasswordGenerator.App;
using Random = _12_PasswordGenerator.RandomNumberGenerator.Random;

var passwordGenerator = new PasswordGenerator(new Random());
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(passwordGenerator.Generate(5, 10, false));
}
Console.ReadKey();


