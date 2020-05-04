using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models
{
    public class CartProduct
    {
        public int ID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        // nav props
        // public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
