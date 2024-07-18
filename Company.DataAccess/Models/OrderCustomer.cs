using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataAccess.Models
{
    public class OrderCustomer
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
