using MagicalGoods.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        ID = 1,
                        Name = "Baby Hippogriff Feather",
                        Price = 100.00m,
                        Description = "A feather taken from an empty hippogryff nest that belonged to a young hippogriff!",
                        Image = "https://magicalgoodsblob.blob.core.windows.net/products/Quill.jpg"
                    },
                    new Product
                    {
                        ID = 2,
                        Name = "Used Flying Broomstick",
                        Price = 1200.00m,
                        Description = "A 2018 Cumulo 1000 broomstick, top speed 27mph!",
                        Image = "https://magicalgoodsblob.blob.core.windows.net/products/broom.jpeg"
                    },
                    new Product
                    {
                        ID = 3,
                        Name = "Every Flavor Jellybeans",
                        Price = 2.00m,
                        Description = "No, really, EVERY flavor!",
                        Image = "https://magicalgoodsblob.blob.core.windows.net/products/Bertie_Botts.png"
                    },
                    new Product
                    {
                        ID = 4,
                        Name = "Chocolate Frog",
                        Price = 1.50m,
                        Description = "Chocolate Frog that really hops and has the card of a witch or wizard!",
                        Image = "https://magicalgoodsblob.blob.core.windows.net/products/frog.jpg"
                    },
                    new Product
                    {
                        ID = 5,
                        Name = "Auto-answer Quill",
                        Price = 500.00m,
                        Description = "Touch it to any question, and it will write the answer!",
                        Image = "https://magicalgoodsblob.blob.core.windows.net/products/Quill-lrg.png"
                    },
                    new Product
                    {
                        ID = 6,
                        Name = "Bag of Holding",
                        Price = 400.00m,
                        Description = "A bag with considerably more space inside than it appears at first glance. Holds up to 500lbs, but only ever weighs 15!",
                        Image = "https://magicalgoodsblob.blob.core.windows.net/products/bag-of-holding.jpeg"
                    },
                    new Product
                    {
                        ID = 7,
                        Name = "Immovable Rod",
                        Price = 50.00m,
                        Description = "Just press a button, and this rod will fix itself in place. Defy gravity!",
                        Image = "https://magicalgoodsblob.blob.core.windows.net/products/rod.jpeg"
                    },
                    new Product
                    {
                        ID = 8,
                        Name = "Polyjuice Potion",
                        Price = 150.00m,
                        Description = "Magically transform into anyone with just a small piece of their hair!",
                        Image = "https://magicalgoodsblob.blob.core.windows.net/products/polyjuice.jpg"
                    },
                    new Product
                    {
                        ID = 9,
                        Name = "Slippers of Spider Climb",
                        Price = 250.00m,
                        Description = "Put on these slippers, and walk on any surface!",
                        Image = "https://magicalgoodsblob.blob.core.windows.net/products/slippers.jpeg"
                    },
                    new Product
                    {
                        ID = 10,
                        Name = "Pheonix-core Wand",
                        Price = 1000.00m,
                        Description = "A powerful wand with a core made from the feather of a pheonix",
                        Image = "https://magicalgoodsblob.blob.core.windows.net/products/wand.png"
                    }
                ); ;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
