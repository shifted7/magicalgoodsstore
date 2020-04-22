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
                        Image = "https://pm1.narvii.com/6511/68a4998e3c775db2e30db7aca026aadf997d34ca_hq.jpg"
                    },
                    new Product
                    {
                        ID = 2,
                        Name = "Used Flying Broomstick",
                        Price = 1200.00m,
                        Description = "A 2018 Cumulo 1000 broomstick, top speed 27mph!",
                        Image = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/152/1000/1000/636284717908019789.jpeg"
                    },
                    new Product
                    {
                        ID = 3,
                        Name = "Every Flavor Jellybeans",
                        Price = 2.00m,
                        Description = "No, really, EVERY flavor!",
                        Image = "https://vignette.wikia.nocookie.net/harrypotter/images/6/60/Bertie_Botts_EFB.png/revision/latest?cb=20161128010133"
                    },
                    new Product
                    {
                        ID = 4,
                        Name = "Chocolate Frog",
                        Price = 1.50m,
                        Description = "Chocolate Frog that really hops and has the card of a witch or wizard!",
                        Image = "https://images-na.ssl-images-amazon.com/images/I/91rOTxaOA3L._AC_SL1500_.jpg"
                    },
                    new Product
                    {
                        ID = 5,
                        Name = "Auto-answer Quill",
                        Price = 500.00m,
                        Description = "Touch it to any question, and it will write the answer!",
                        Image = "https://img1.wikia.nocookie.net/__cb20121112222214/harrypotter/images/d/d0/Quill-lrg.png"
                    },
                    new Product
                    {
                        ID = 6,
                        Name = "Bag of Holding",
                        Price = 400.00m,
                        Description = "A bag with considerably more space inside than it appears at first glance. Holds up to 500lbs, but only ever weighs 15!",
                        Image = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/120/1000/1000/636284708068284913.jpeg"
                    },
                    new Product
                    {
                        ID = 7,
                        Name = "Immovable Rod",
                        Price = 50.00m,
                        Description = "Just press a button, and this rod will fix itself in place. Defy gravity!",
                        Image = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/261/1000/1000/636284741670235041.jpeg"
                    },
                    new Product
                    {
                        ID = 8,
                        Name = "Polyjuice Potion",
                        Price = 150.00m,
                        Description = "Magically transform into anyone with just a small piece of their hair!",
                        Image = "https://i.stack.imgur.com/LerE3.jpg"
                    },
                    new Product
                    {
                        ID = 9,
                        Name = "Slippers of Spider Climb",
                        Price = 250.00m,
                        Description = "Put on these slippers, and walk on any surface!",
                        Image = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/402/1000/1000/636284767446806965.jpeg"
                    },
                    new Product
                    {
                        ID=10,
                        Name = "Pheonix-core Wand",
                        Price = 1000.00m,
                        Description = "A powerful wand with a core made from the feather of a pheonix"
                    }

                );
        }

        public DbSet<Product> Products { get; set; }


    }
}
