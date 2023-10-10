namespace UtilityTests
{
    internal class TestHelper
    {

        internal static string GenerateRandomCode(int length)
        {
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] chars = new char[length];
            Random random = new Random();

            for (int i = 0; i < length; i++)
                chars[i] = allowedChars[random.Next(0, allowedChars.Length)];

            return new string(chars);
        }
    }
}
