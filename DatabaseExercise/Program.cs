using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DatabaseExercise
{

    class Program
    {
        static void Main(string[] args)
        {

            var products = GetAllProducts();

            foreach (var product in products)
            {
                System.Console.WriteLine($"id: {product.ProductId} name: {product.Name} price: {product.Price}");
            }

        }

        static List<Product> GetAllProducts()
        {
            List<Product> products = null;

            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "select * from products";

                    MySqlCommand command = new MySqlCommand(sql, connection);

                    MySqlDataReader reader = command.ExecuteReader();

                    products = new List<Product>();

                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = int.Parse(reader["id"].ToString()),
                            Name = reader["product_name"].ToString(),
                            Price = double.Parse(reader["list_price"]?.ToString())
                        });

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

            return products;
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
