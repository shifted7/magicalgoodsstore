using MagicalGoods.Data;
using MagicalGoods.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using MagicalGoods;
using System.Threading.Tasks;
using MagicalGoods.Models.Services;
using System.Collections.Generic;

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
            using (StoreDbContext context = new StoreDbContext(options))
            {
                ProductService ps = new ProductService(context);
                Product testProduct = new Product
                {
                    ID = 1,
                    Name = "Test",
                    Price = 10.00m,
                    Description = "Test Description",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Test.png"
                };

                var result = await ps.CreateProductAsync(testProduct);
                var data = context.Products.Find(testProduct.ID);
                Assert.Equal(result, data);
            }
        }

        [Fact]
        public async Task TestCanGetProductFromDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("TestCanGetProductFromDatabase")
                .Options;

            // open the connection to the database
            using (StoreDbContext context = new StoreDbContext(options))
            {
                ProductService ps = new ProductService(context);
                Product testProduct = new Product
                {
                    ID = 1,
                    Name = "Test",
                    Price = 10.00m,
                    Description = "Test Description",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Test.png"
                };

                var addedProduct = await ps.CreateProductAsync(testProduct);
                var getProduct = await ps.GetProductByIdAsync(testProduct.ID);
                Assert.Equal(addedProduct, getProduct);
            }
        }

        [Fact]
        public async Task TestCanGetAllProductsFromDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("TestCanGetAllProductsFromDatabase")
                .Options;

            // open the connection to the database
            using (StoreDbContext context = new StoreDbContext(options))
            {
                ProductService ps = new ProductService(context);
                
                Product testProductA = new Product
                {
                    ID = 1,
                    Name = "TestA",
                    Price = 10.00m,
                    Description = "Test Description A",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Test.png"
                };
                Product testProductB = new Product
                {
                    ID = 2,
                    Name = "TestB",
                    Price = 20.00m,
                    Description = "Test Description B",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Test.png"
                };

                List<Product> expectedProducts = new List<Product>();
                expectedProducts.Add(testProductA);
                expectedProducts.Add(testProductB);

                await ps.CreateProductAsync(testProductA);
                await ps.CreateProductAsync(testProductB);

                List<Product> getAllProducts = await ps.GetAllProductsAsync();

                Assert.Equal(expectedProducts, getAllProducts);
            }
        }

        [Fact]
        public async Task TestCanDeleteProductFromDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("TestCanDeleteProductFromDatabase")
                .Options;

            // open the connection to the database
            using (StoreDbContext context = new StoreDbContext(options))
            {
                ProductService ps = new ProductService(context);
                Product testProduct = new Product
                {
                    ID = 1,
                    Name = "Test",
                    Price = 10.00m,
                    Description = "Test Description",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Test.png"
                };

                await ps.CreateProductAsync(testProduct);
                await ps.RemoveProductByIdAsync(testProduct.ID);
                var noProduct = await ps.GetProductByIdAsync(testProduct.ID);
                Assert.Null(noProduct);
            }
        }

        [Fact]
        public async Task TestCanUpdateProductInDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("TestCanUpdateProductInDatabase")
                .Options;

            // open the connection to the database
            using (StoreDbContext context = new StoreDbContext(options))
            {
                ProductService ps = new ProductService(context);
                Product testProduct = new Product
                {
                    Name = "Test",
                    Price = 10.00m,
                    Description = "Test Description",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Test.png"
                };
                await ps.CreateProductAsync(testProduct);

                string updatedName = "Updated Name";
                testProduct.Name = updatedName;

                await ps.UpdateProductAsync(testProduct);
                var result = await ps.GetProductByIdAsync(testProduct.ID);

                Assert.Equal(updatedName, result.Name);
            }
        }


        [Fact]
        public void CanCreateEmptyCart()
        {
            Cart cart = new Cart();
            Assert.Equal(0, cart.UserId);
        }

        [Fact]
        public async void CanAddCartToUser()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
            .UseInMemoryDatabase("CanAddCartToUserTest")
            .Options;

            using(StoreDbContext cartContext = new StoreDbContext(options))
            {
                CartService cs = new CartService(cartContext);

                Cart addedCart = await cs.AddCartToUser(1);

                var result = await cs.GetCartByID(addedCart.ID);

                Assert.Equal(1, result.UserId);
            };
        }

        [Fact]
        public async void CanAddProductToCart()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
            .UseInMemoryDatabase("CanAddProductToCartTest")
            .Options;

            using (StoreDbContext storeContext = new StoreDbContext(options))
            {
                CartProductService cps = new CartProductService(storeContext);

                CartProduct cartProduct = await cps.AddProductToCart(3, 7, 2);

                List<CartProduct> result = await cps.GetAllProductsForCart(7);
                Assert.Single(result);
            };
        }

        //[Fact]
        //public async void CanRemoveProduct()
        //{
        //    DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
        //    .UseInMemoryDatabase("CanRemoveProductTest")
        //    .Options;

        //    using (StoreDbContext storeContext = new StoreDbContext(options))
        //    {
        //        CartProductService cps = new CartProductService(storeContext);

        //        CartProduct cartProduct = await cps.AddProductToCart(2, 4, 1);

        //        await cps.RemoveProduct(2, 4);

        //        var result = await cps.GetAllProductsForCart(2);

        //        Assert.Empty(result);
        //    };

        //}


    }
}