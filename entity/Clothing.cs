using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.entity
{
    internal class Clothing : Product
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public Clothing(int productId, string productName, string description, double price, int quantityInStock, string type) : base(productId, productName, description, price, quantityInStock, type)
        {
        }

        public override string ToString()
        {
            return $"\nProduct ID::{ProductID}\t Product Name::{ProductName}\t Product Description::{Description}\t Product Price::{Price}\t QuantityInStock::{QuantityInStock}\t Product Type::{ProductType}\t Size::{Size}\t WarrantyPeriod::{Color}\n";
        }
    }
}
