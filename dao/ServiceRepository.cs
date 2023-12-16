using Order_Management_System.entity;
using Order_Management_System.exception;

namespace Order_Management_System.dao
{
    internal class ServiceRepository:IServiceRepository
    {
        IOrderManagementRepository orderManagementRepository = new OrderManagementRepository();

        public void createOrder()
        {
            try
            {
                Console.WriteLine("\nEnter User ID:");
                int inputUserID = int.Parse(Console.ReadLine());
                List<Users> users = orderManagementRepository.getAllUsers();
                Users searchedUser = users.Find(x => x.UserID == inputUserID);
                if (searchedUser == null)
                {
                    throw new UserNotFoundException($"User ID {inputUserID} does not exist");
                }

                Console.WriteLine("\nSelect from the below Product List:");
                getAllProducts();

                List<Product> addedProducts = new List<Product>();
                restart:
                Console.WriteLine("\nEnter Product ID:");
                int inputProductID = int.Parse(Console.ReadLine());
                List<Product> products = orderManagementRepository.getAllProducts();
                Product searchedProduct = products.Find(x => x.ProductID == inputProductID);
                if (searchedProduct == null)
                {
                    throw new ProductNotFoundException($"Product ID {inputProductID} does not exist");
                }
                Console.WriteLine("\nAdd more Products?:\n 1.Yes \t 2.No");
                int userChoice = int.Parse(Console.ReadLine());
                if (userChoice == 1)
                {
                    addedProducts.Add(searchedProduct);
                    goto restart;
                }
                else if (userChoice == 2)
                {
                    addedProducts.Add(searchedProduct);
                    if (orderManagementRepository.createOrder(searchedUser,addedProducts))
                    {
                        Console.WriteLine("\nYour Order was placed successfully\n");
                    }
                    else
                    {
                        Console.WriteLine($"Unable to place your order\n");
                    }
                }

            }
            catch (System.Exception e)
            {
                Console.WriteLine($"\n{e.Message}\n");
            }
        }

        public void cancelOrder()
        {
            try
            {
                Console.WriteLine("\nEnter User ID:");
                int inputUserID = int.Parse(Console.ReadLine());

                Console.WriteLine("\nEnter Order ID:");
                int inputOrderID = int.Parse(Console.ReadLine());

                if(orderManagementRepository.cancelOrder(inputUserID,inputOrderID))
                {
                    Console.WriteLine("\nYour Order was cancelled successfully\n");
                }
                else
                {
                    Console.WriteLine("Unable to cancel your order\n");
                }

            }
            catch(Exception e)
            {
                Console.WriteLine($"\n{e.Message}\n");
            }
        }

        public void createProduct()
        {
            try
            {
                Console.WriteLine("\nEnter User ID:");
                int inputUserID = int.Parse(Console.ReadLine());
                List<Users> users = orderManagementRepository.getAllUsers();
                Users searchedUser = users.Find(x => x.UserID == inputUserID);
                if (searchedUser == null)
                {
                    throw new UserNotFoundException($"User ID {inputUserID} does not exist");
                }

                Console.WriteLine("\nEnter Product Name:");
                string inputProductName = Console.ReadLine();
                Console.WriteLine("\nEnter Product Description:");
                string inputProductDescription = Console.ReadLine();
                Console.WriteLine("\nEnter Product Price:");
                double inputProductPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter Quantity In Stock:");
                int inputQuantityInStock = int.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter Product Type:");
                string inputProductType = Console.ReadLine();

                Product product = new Product(0, inputProductName, inputProductDescription, inputProductPrice, inputQuantityInStock, inputProductType);

                if (orderManagementRepository.createProduct(searchedUser, product))
                {
                    Console.WriteLine("\nYour Product was created successfully\n");
                }
                else
                {
                    Console.WriteLine("Unable to create your Product\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n{e.Message}\n");
            }            
        }

        public void createUser()
        {
            Console.WriteLine("\nEnter User Name:");
            string inputUserName = Console.ReadLine();
            Console.WriteLine("\nEnter User Password:");
            string inputUserPassword = Console.ReadLine();
            Console.WriteLine("\nEnter User Role:");
            string inputUserRole = Console.ReadLine();
            Users user = new Users(0, inputUserName, inputUserPassword, inputUserRole);

            if (orderManagementRepository.createUser(user))
            {
                Console.WriteLine("\nUser created successfully\n");
            }
            else
            {
                Console.WriteLine("Unable to create user\n");
            }
        }

        public void getOrderByUser()
        {
            try
            {
                Console.WriteLine("\nEnter User ID:");
                int inputUserID = int.Parse(Console.ReadLine());
                List<Users> users = orderManagementRepository.getAllUsers();
                Users searchedUser = users.Find(x => x.UserID == inputUserID);
                if (searchedUser == null)
                {
                    throw new UserNotFoundException($"User ID {inputUserID} does not exist");
                }

                Console.WriteLine("\nAll user Ordered Products");
                List<Product> products = orderManagementRepository.getOrderByUser(searchedUser);
                if(products.Count == 0)
                {
                    Console.WriteLine($"\nNo Order history for UserID {inputUserID}\n");
                }
                else
                {
                    foreach (var product in products)
                    {
                        Console.WriteLine(product);
                    }
                    Console.WriteLine("");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"\n{e.Message}\n");
            }
        }

        public void getAllProducts()
        {
            Console.WriteLine("\nAll Products");
            List<Product> products = orderManagementRepository.getAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("");
        }



        public void getAllUsers()
        {
            Console.WriteLine("\nAll Users");
            List<Users> users = orderManagementRepository.getAllUsers();
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine("");
        }

        public void getAllOrders()
        {
            Console.WriteLine("\nAll Orders");
            List<Orders> orders = orderManagementRepository.getAllOrders();
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
            Console.WriteLine("");
        }

        public void executeElectronicsClass()
        {
            Electronics electronics = new Electronics(1, "TV", "O-LEd", 50000, 45, "Electronics");
            electronics.Brand = "Toshiba";
            electronics.WarrantyPeriod = 1;

            Console.WriteLine(electronics);
        }

        public void executeClothingClass()
        {
            Clothing clothing = new Clothing(1, "Jeans", "High Quality", 1500, 50, "Clothing");
            clothing.Size = "34";
            clothing.Color = "Blue";

            Console.WriteLine(clothing);
        }
    }
}
