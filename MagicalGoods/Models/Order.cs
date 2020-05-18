using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateOfOrder { get; set; }
        public decimal TotalPrice { get; set; }
        public Cart Cart { get; set; }

    }
}
