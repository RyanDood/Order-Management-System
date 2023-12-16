using Order_Management_System.entity;
using Order_Management_System.exception;
using Order_Management_System.util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.dao
{
    internal class OrderManagementRepository : IOrderManagementRepository
    {

        string connectionString = DBConnUtil.getConnnectionString();

        public bool createOrder(Users user, List<Product> products)
        {
            bool status = false;
            foreach(Product product in products)
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.CommandText = "insert into Orders values (@userID,@productID)";
                        sqlCommand.Parameters.AddWithValue("@userID", user.UserID);
                        sqlCommand.Parameters.AddWithValue("@productID", product.ProductID);
                        sqlCommand.Connection = sqlConnection;
                        sqlConnection.Open();
                        int createOrderStatus = sqlCommand.ExecuteNonQuery();
                        if (createOrderStatus > 0)
                        {
                            status = true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n{e.Message}\n");
                    status = false;
                }
            }
            return status;
        }



        public bool cancelOrder(int userId, int orderId)
        {
            bool status = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "delete from Orders where userId = @userID and orderId = @orderID ";
                    sqlCommand.Parameters.AddWithValue("@userID", userId);
                    sqlCommand.Parameters.AddWithValue("@orderID", orderId);
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    int deleteOrderStatus = sqlCommand.ExecuteNonQuery();
                    if (deleteOrderStatus == 0)
                    {
                        throw new OrderNotFoundException($"\nOrder ID {orderId} or UserID {userId} does not exist::");
                    }
                    else if (deleteOrderStatus > 0)
                    {
                        status = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                status = false;
            }
            return status;
        }


        public bool createProduct(Users user, Product product)
        {
            bool status = false;
            try
            {
                if(user.Role == "Admin")
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.CommandText = "insert into Product values (@productName,@description,@amount,@stock,@type)";
                        sqlCommand.Parameters.AddWithValue("@productName", product.ProductName);
                        sqlCommand.Parameters.AddWithValue("@description", product.Description);
                        sqlCommand.Parameters.AddWithValue("@amount", product.Price);
                        sqlCommand.Parameters.AddWithValue("@stock", product.QuantityInStock);
                        sqlCommand.Parameters.AddWithValue("@type", product.ProductType);
                        sqlCommand.Connection = sqlConnection;
                        sqlConnection.Open();
                        int createOrderStatus = sqlCommand.ExecuteNonQuery();
                        if (createOrderStatus > 0)
                        {
                            status = true;
                        }
                    }
                }
                else
                {
                    throw new UserNotFoundException($"User ID {user.UserID} is not an Admin::");
                }
                
            }
            catch (Exception e)
            {
                if (e.GetType().FullName == "System.Data.SqlClient.SqlException") {
                    Console.WriteLine($"\n{"You can only insert the value of Clothing or Electronics for Product Type"}");
                    status = false;
                }
                else
                {
                    Console.WriteLine($"\n{e.Message}");
                    status = false;
                }
               
            }
            return status;
        }

        public bool createUser(Users user)
        {
            bool status = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "insert into Users values (@userName,@userPassword,@role)";
                    sqlCommand.Parameters.AddWithValue("@userName", user.UserName);
                    sqlCommand.Parameters.AddWithValue("@userPassword", user.Password);
                    sqlCommand.Parameters.AddWithValue("@role", user.Role);
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    int createOrderStatus = sqlCommand.ExecuteNonQuery();
                    if (createOrderStatus > 0)
                    {
                        status = true;
                    }
                }
            }
            catch (Exception e)
            {
                if (e.GetType().FullName == "System.Data.SqlClient.SqlException")
                {
                    Console.WriteLine($"\n{"You can only insert the role as either User or Admin"}");
                    status = false;
                }
                else
                {
                    Console.WriteLine($"\n{e.Message}");
                    status = false;
                }
            }
            return status;
        }

        public List<Product> getAllProducts()
        {
            List<Product> allProducts = new List<Product>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "select * from Product";
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        decimal productPrice = (decimal)reader["price"];
                        double convertedPrice = Decimal.ToDouble(productPrice);
                        Product product = new Product((int)reader["productId"], (string)reader["productName"], (string)reader["description"], convertedPrice, (int)reader["quantityInStock"], (string)reader["type"]);
                        allProducts.Add(product);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            return allProducts;
        }

        public List<Product> getOrderByUser(Users user)
        {
            List<Product> userProducts = new List<Product>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "select Product.productId,productName,description,price,quantityInStock,type from Orders inner join Users on Orders.userId = Users.userId inner join Product on Orders.productId = Product.productId where Orders.userId = @userID";
                    sqlCommand.Parameters.AddWithValue("@userID", user.UserID);
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        decimal productPrice = (decimal)reader["price"];
                        double convertedPrice = Decimal.ToDouble(productPrice);
                        Product product = new Product((int)reader["productId"], (string)reader["productName"], (string)reader["description"], convertedPrice, (int)reader["quantityInStock"], (string)reader["type"]);
                        userProducts.Add(product);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            return userProducts;
        }

        public List<Users> getAllUsers()
        {
            List<Users> allUsers = new List<Users>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "select * from Users";
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Users user = new Users((int)reader["userId"], (string)reader["username"], (string)reader["password"], (string)reader["role"]);
                        allUsers.Add(user);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            return allUsers;
        }

        public List<Orders> getAllOrders()
        {
            List<Orders> allOrders = new List<Orders>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "select * from orders";
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Orders order = new Orders((int)reader["orderId"], (int)reader["userId"], (int)reader["productId"]);
                        allOrders.Add(order);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            return allOrders;
        }
    }
}
