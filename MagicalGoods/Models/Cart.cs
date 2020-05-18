using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string UserId { get; set; }

        public List<CartProduct> CartProducts { get; set; }
    }
}
