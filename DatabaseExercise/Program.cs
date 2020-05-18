using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DatabaseExercise
{

    public interface IProductDal
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        List<Product> Find(string productName);
        int Count();
        void Create(Product product);
        void Update(Product product);
        void Delete(int productId);

    }

    public class MySQLProductDal : IProductDal
    {
        private MySqlConnection GetMySqlConnection()
        {
            string connectionString = @"server=localhost;port=3306;database=northwind;user=root;password=123456789;";

            // driver, provider

            return new MySqlConnection(connectionString);
        }
        public void Create(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
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

        public Product GetProductById(int id)
        {
            Product product = null;

            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "select * from products where id=@ProductId";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.Add("ProductId", MySqlDbType.Int32).Value = id;

                    MySqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    if (reader.HasRows)
                    {
                        product = new Product()
                        {
                            ProductId = int.Parse(reader["id"].ToString()),
                            Name = reader["product_name"].ToString(),
                            Price = double.Parse(reader["list_price"]?.ToString())
                        };
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

            return product;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> Find(string productName)
        {
            List<Product> products = null;

            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "select * from products where product_name LIKE @productName";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.Add("@productName", MySqlDbType.String).Value = "%" + productName + "%";

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

        public int Count()
        {
            int count = 0;

            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "select count(*) from products";

                    MySqlCommand command = new MySqlCommand(sql, connection);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        count = Convert.ToInt32(result.ToString());
                    }

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

            return count;
        }
    }

    public class MsSQLProductDal : IProductDal
    {
        private SqlConnection GetMsSqlConnection()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";

            // driver, provider

            return new SqlConnection(connectionString);
        }
        public void Create(Product product)
        {
            using (var connection = GetMsSqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "insert into products (ProductName,UnitPrice,Discontinued) VALUES (@productname,@unitprice,@discontinued)";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@productName", product.Name);
                    command.Parameters.AddWithValue("@unitPrice", product.Price);
                    command.Parameters.AddWithValue("@discontinued", 0);

                    int result = command.ExecuteNonQuery();
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

        public void Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = null;

            using (var connection = GetMsSqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "select * from products";

                    SqlCommand command = new SqlCommand(sql, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    products = new List<Product>();

                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = int.Parse(reader["ProductId"].ToString()),
                            Name = reader["ProductName"].ToString(),
                            Price = double.Parse(reader["UnitPrice"]?.ToString())
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

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> Find(string productName)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }

    public class ProductManager : IProductDal
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public int Count()
        {
            return _productDal.Count();
        }

        public void Create(Product product)
        {
            _productDal.Create(product);
        }

        public void Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> Find(string productName)
        {
            return _productDal.Find(productName);
        }

        public List<Product> GetAllProducts()
        {
            return _productDal.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productDal.GetProductById(id);
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var productDal = new ProductManager(new MsSQLProductDal());

            productDal.Create(new Product()
            {
                Name = "Arif Damar's product",
                Price = 10000
            });

        }

    }
}
