using MagicalGoods.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Data
{
    public class MagicalGoodsDbContext : DbContext
    {
        public MagicalGoodsDbContext(DbContextOptions<MagicalGoodsDbContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }

    }
}
