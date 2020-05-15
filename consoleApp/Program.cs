using System;

namespace consoleApp {

    class Product {
        public string Name { get; set; }
    }

    class Program {
        static void Main (string[] args) {
            // Exception

            // System.FormatException
            // System.DivideByZeroException

            Console.Write ("Number1: ");
            int number1 = int.Parse (Console.ReadLine ());

            Console.Write ("Number2: ");
            int number2 = int.Parse (Console.ReadLine ());

            var result = number1 / number2;

            // System.IndexOutOfRangeException
            int[] numbers = new int[2];

            numbers[2] = 10;
            

            Product p = null;

            // System.NullReferenceException            
            Console.WriteLine (p.Name);

            // Exception handling

        }
    }
}