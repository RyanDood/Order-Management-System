using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.entity
{
    internal class Product
    {
        int productId;
        string productName;
        string description;
        double price;
        int quantityInStock;
        string type;

        public Product(int productId,string productName, string description, double price, int quantityInStock, string type)
        {
            this.productId = productId;
            this.productName = productName;
            this.description = description;
            this.price = price;
            this.quantityInStock = quantityInStock;
            this.type = type;
        }

        public int ProductID
        {
            get
            {
                return this.productId;
            }
            set
            {
                productId = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                productName = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                description = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                price = value;
            }
        }

        public int QuantityInStock
        {
            get
            {
                return this.quantityInStock;
            }
            set
            {
                quantityInStock = value;
            }
        }

        public string ProductType
        {
            get
            {
                return this.type;
            }
            set
            {
                type= value;
            }
        }

        public override string ToString()
        {
            return $"Product ID::{ProductID}\t Product Name::{ProductName}\t Product Description::{Description}\t Product Price::{Price}\t QuantityInStock::{QuantityInStock}\t Product Type::{ProductType}";
        }

    }
}
