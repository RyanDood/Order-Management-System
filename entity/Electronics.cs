using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.entity
{
    internal class Electronics : Product
    {
        public string Brand { get; set; }

        public int WarrantyPeriod { get; set; }

        public Electronics(int productId, string productName, string description, double price, int quantityInStock, string type) : base(productId, productName, description, price, quantityInStock, type)
        {

        }

        public override string ToString()
        {
            return $"\nProduct ID::{ProductID}\t Product Name::{ProductName}\t Product Description::{Description}\t Product Price::{Price}\t QuantityInStock::{QuantityInStock}\t Product Type::{ProductType}\t BrandName::{Brand}\t WarrantyPeriod::{WarrantyPeriod}\n";
        }
    }
}
