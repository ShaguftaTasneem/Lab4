using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BusinessLayer
{
   public class OrderDetails
    {

        public int OrderID { get; set; }
        public String ProductID { get; set; }
        public decimal? UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Double Discount { get; set; }
       



          }
}
