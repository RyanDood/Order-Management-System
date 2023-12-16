using Order_Management_System.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.dao
{
    internal interface IOrderManagementRepository
    {
        public bool createOrder(Users user, List<Product> products);
        public bool cancelOrder(int userId, int orderId);
        public bool createProduct(Users user, Product product);
        public bool createUser(Users user);
        public List<Product> getAllProducts();
        public List<Product> getOrderByUser(Users user);
        public List<Users> getAllUsers();
        public List<Orders> getAllOrders();
    }
}
