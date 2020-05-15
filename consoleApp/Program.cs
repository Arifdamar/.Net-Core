using System;
using System.Linq;

namespace consoleApp
{

    class Person
    {
        string _name;

        public string Name
        {
            get {
                return _name;
            }
            set {
                if(value.Length>15)
                    throw new Exception("Length must be less than 15 charaters");
                _name = value;
            }
        }
    }

    class Program
    {

        static void check_password(string password)
        {
            if(password.Length < 8 || password.Length > 15)
            {
                throw new Exception("Password must be beetween 7-15 characters");
            }
            if(!password.Any(char.IsDigit))
            {
                throw new Exception("Password must contain at least 1 digit");
            }
            if(!password.Any(char.IsLetter))
            {
                throw new Exception("Password must contain at least 1 letter");
            }
        }

        static void Main(string[] args)
        {
            
            // Exception handling

            // string password = "";

            // try
            // {
            //     check_password(password);
            //     System.Console.WriteLine("Password is valid.");
            // }
            // catch (Exception ex)
            // {
            //     System.Console.WriteLine(ex.Message);
            // }


            var p = new Person();
            p.Name = "ArifArifArifArif";

        }
    }
}