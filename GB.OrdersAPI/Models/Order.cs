using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.OrdersAPI.Models
{
    public class Order
    {
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderedDateTime { get; set; }

    }
}