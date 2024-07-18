using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Dto.Product
{
    public class ReadProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public string VendorName { get; set; }
        public int Qty { get; set; }
        public float Weight { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
