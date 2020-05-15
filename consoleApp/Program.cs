using System;
using System.Linq;

namespace consoleApp
{

    class LoginException: Exception
    {
        public LoginException(string message):base(message)
        {
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Login("arifdamar", "12345678");
                System.Console.WriteLine("Login successful");
            }
            catch (LoginException ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }

        }

        static void Login(string username, string password)
        {
            if(username.Contains(" "))
            {
                throw new LoginException("Username cannot contain space character");
            }
            if(password.Length<8)
            {
                throw new LoginException("Password must be at least 8 characters");
            }
        }
    }
}