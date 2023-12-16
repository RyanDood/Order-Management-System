using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.entity
{
    internal class Orders
    {
        int orderId;
        int userId;
        int productId;

        public Orders(int orderId, int userId, int productId)
        {
            this.orderId = orderId;
            this.userId = userId;
            this.productId = productId;
        }
        
        public int OrderID
        {
            get
            {
                return orderId;
            }
            set
            {
                orderId = value;
            }
        }

        public int UserID
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        public int ProductID
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }

        public override string ToString()
        {
            return $"Order ID::{OrderID}\t User ID::{UserID}\t Product ID::{ProductID}\t";
        }
    }
}
