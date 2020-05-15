using System;

namespace consoleApp
{

    class Product
    {
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Exception

            // System.FormatException
            // System.DivideByZeroException
            // System.IndexOutOfRangeException
            // System.NullReferenceException            


            // Exception handling

            try
            {

                Console.Write("a: ");
                int a = int.Parse(Console.ReadLine());

                Console.Write("b: ");
                int b = int.Parse(Console.ReadLine());

                var result = a / b;

                Console.WriteLine("{0} / {1} = {2}", a, b, result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Second number cannot be 0");
                System.Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Invalid format");
                System.Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("An error occured");
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                System.Console.WriteLine("Finally works!");
            }


        }
    }
}