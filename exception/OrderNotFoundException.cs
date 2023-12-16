using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.exception
{
    internal class OrderNotFoundException:ApplicationException
    {
        public OrderNotFoundException(string msg) : base(msg)
        {

        }
    }
}
