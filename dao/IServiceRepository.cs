using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.dao
{
    internal interface IServiceRepository
    {
        public void createOrder();
        public void cancelOrder();
        public void createProduct();
        public void createUser();
        public void getOrderByUser();
        public void getAllProducts();
        public void getAllUsers();
        public void getAllOrders();
        public void executeElectronicsClass();
        public void executeClothingClass();
    }
}
