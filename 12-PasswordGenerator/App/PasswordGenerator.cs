using _12_PasswordGenerator.RandomNumberGenerator;

namespace _12_PasswordGenerator.App
{
    public class PasswordGenerator
    {
        private readonly IRandom _random;

        public PasswordGenerator(IRandom random)
        {
            _random = random;
        }
        public string Generate(
            int minPasswordLength, int maxPasswordLength, bool shallUseSpecialCharacter)
        {

            Validate(minPasswordLength, maxPasswordLength);
            int passwordLength = GeneratePasswordLength(minPasswordLength, maxPasswordLength);
            string passwordCharacters = GetPasswordCharacters(shallUseSpecialCharacter);

            return new string(Enumerable.Repeat(passwordCharacters, passwordLength)
                .Select(chars => chars[_random.Next(chars.Length)]).ToArray());
        }

        private int GeneratePasswordLength(int minPasswordLength, int maxPasswordLength)
        {
            return _random.Next(minPasswordLength, maxPasswordLength + 1);
        }

        private static string GetPasswordCharacters(bool useSpecial)
        {

           
            return useSpecial ?
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=" :
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        }

        private static void Validate(int minPasswordLength, int maxPasswordLength)
        {
            if (minPasswordLength < 1)
            {
                throw new ArgumentOutOfRangeException(
                    $"{nameof(minPasswordLength)} must be greater than 0");
            }
            if (maxPasswordLength < minPasswordLength)
            {
                throw new ArgumentOutOfRangeException(
                    $"{nameof(minPasswordLength)} must be smaller than {nameof(maxPasswordLength)}");
            }
        }
    }
}