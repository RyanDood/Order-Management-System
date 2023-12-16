using Order_Management_System.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.main
{
    internal class MainModule
    {
        ServiceRepository repository = new ServiceRepository();

        public void dashboard()
        {
            Console.WriteLine("-----------------------------------------------------Welcome to Order Management System-----------------------------------------------------\n\n");
            restart:
            Console.WriteLine("Please Select from below\n");
            Console.WriteLine("1. Create Order\n2. Cancel Order\n3. Create Product.\n4. Create User.\n5. Get All Products\n6. Get Order by Users.\n7. Get All Users\n8. Get All Orders\n9. Execute Electronics Class\n10. Execute Clothing Class\n");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    repository.createOrder();
                    break;
                case 2:
                    repository.cancelOrder();
                    break;
                case 3:
                    repository.createProduct();
                    break;
                case 4:
                    repository.createUser();
                    break;
                case 5:
                    repository.getAllProducts();
                    break;
                case 6:
                    repository.getOrderByUser();
                    break;
                case 7:
                    repository.getAllUsers();
                    break;
                case 8:
                    repository.getAllOrders();
                    break;
                case 9:
                    repository.executeElectronicsClass();
                    break;
                case 10:
                    repository.executeClothingClass();
                    break;
                default:
                    Console.WriteLine("\nTry Again\n");
                    break;
            }
            goto restart;
        }
            
    }
}
