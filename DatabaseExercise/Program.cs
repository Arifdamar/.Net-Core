using System;
using System.Data.SqlClient;

namespace DatabaseExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            
            GetSqlConnection();

        }

        static void GetSqlConnection()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";

            // driver, provider

            using(var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    System.Console.WriteLine("Connection Successful");
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
                
            }
            

        }
    }
}
