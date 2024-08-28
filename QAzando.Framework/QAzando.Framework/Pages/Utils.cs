using Faker;

namespace QAzando.Framework.Utils
{
    public static class DataGenerator
    {
        public static string FirstName { get; private set; }
        public static string Email { get; private set; }
        public static string Password { get; private set; }

        public static void GenerateUserData()
        {
            FirstName = Name.First();
            Email = Internet.Email();
            Password = string.Concat(Internet.UserName(), RandomNumber.Next(1000, 9999));
        }
    }
}
