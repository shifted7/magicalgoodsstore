using MagicalGoods.Data;
using MagicalGoods.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using MagicalGoods;
using System.Threading.Tasks;

namespace MagicalGoodsTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestCanSetProductId()
        {
            Product testProduct = new Product
            {
                ID = 1,
                Name = "Test",
                Price = 10.00m,
                Description = "Test Description",
                Image = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Test.png"
            };
            testProduct.ID = 5;
            Assert.Equal(5, testProduct.ID);
        }

        [Fact]
        public void TestCanSetProductName()
        {
            Product testProduct = new Product
            {
                ID = 1,
                Name = "Test",
                Price = 10.00m,
                Description = "Test Description",
                Image = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Test.png"
            };
            testProduct.Name = "New name";
            Assert.Equal("New name", testProduct.Name);
        }

        [Fact]
        public void TestCanSetProductPrice()
        {
            Product testProduct = new Product
            {
                ID = 1,
                Name = "Test",
                Price = 10.00m,
                Description = "Test Description",
                Image = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Test.png"
            };
            testProduct.Price = 50.00m;
            Assert.Equal(50.00m, testProduct.Price);
        }

        [Fact]
        public void TestCanSetProductDescription()
        {
            Product testProduct = new Product
            {
                ID = 1,
                Name = "Test",
                Price = 10.00m,
                Description = "Test Description",
                Image = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Test.png"
            };
            testProduct.Description = "A new description.";
            Assert.Equal("A new description.", testProduct.Description);
        }

        [Fact]
        public void TestCanSetProductImage()
        {
            Product testProduct = new Product
            {
                ID = 1,
                Name = "Test",
                Price = 10.00m,
                Description = "Test Description",
                Image = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Test.png"
            };
            testProduct.Image = "https://image.shutterstock.com/image-illustration/full-hd-size-169-television-260nw-1448526302.jpg";
            Assert.Equal("https://image.shutterstock.com/image-illustration/full-hd-size-169-television-260nw-1448526302.jpg", testProduct.Image);
        }

        [Fact]
        public async Task TestCanAddProductToDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("TestCanAddProductToDatabase")
                .Options;

            // open the connection to the database
            //using (CMSDbContext context = new CMSDbContext(options))

            //    Product testProduct = new Product
            //{
            //    ID = 1,
            //    Name = "Test",
            //    Price = 10.00m,
            //    Description = "Test Description",
            //    Image = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Test.png"
            //};
            


        }
    }
}
