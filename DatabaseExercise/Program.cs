using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DatabaseExercise
{
    class Program
    {
        static void Main(string[] args)
        {

            //GetSqlConnection();
            GetMySqlConnection();

        }

        static void GetMySqlConnection()
        {

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";

            // driver, provider

            using (var connection = new SqlConnection(connectionString))
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

        static void GetSqlConnection()
        {
            string connectionString = @"server=localhost;port=3306;database=northwind;user=root;password=123456789;";

            // driver, provider

            using (var connection = new MySqlConnection(connectionString))
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
