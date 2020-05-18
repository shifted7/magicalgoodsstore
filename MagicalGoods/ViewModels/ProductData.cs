using MagicalGoods.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.ViewModels
{
    public class ProductData
    {
        public Product Product { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
