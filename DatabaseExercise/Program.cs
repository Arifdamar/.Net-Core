using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DatabaseExercise
{
    class Program
    {
        static void Main(string[] args)
        {

            GetAllProducts();

        }

        static void GetAllProducts()
        {
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "select * from products";

                    MySqlCommand command = new MySqlCommand(sql, connection);

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"name: {reader[3]} price: {reader[6]}");
                    }

                    reader.Close();

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

        static MySqlConnection GetMySqlConnection()
        {
            string connectionString = @"server=localhost;port=3306;database=northwind;user=root;password=123456789;";

            // driver, provider

            return new MySqlConnection(connectionString);
        }

    }
}
