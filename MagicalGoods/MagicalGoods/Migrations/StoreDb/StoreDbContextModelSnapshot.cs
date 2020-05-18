﻿// <auto-generated />
using System;
using MagicalGoods.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MagicalGoods.Migrations.StoreDb
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MagicalGoods.Models.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("MagicalGoods.Models.CartProduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CartID");

                    b.HasIndex("ProductID");

                    b.ToTable("CartProducts");
                });

            modelBuilder.Entity("MagicalGoods.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CartID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfOrder")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CartID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MagicalGoods.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "A feather taken from an empty hippogryff nest that belonged to a young hippogriff!",
                            Image = "https://magicalgoodsblob.blob.core.windows.net/products/Quill.jpg",
                            Name = "Baby Hippogriff Feather",
                            Price = 100.00m
                        },
                        new
                        {
                            ID = 2,
                            Description = "A 2018 Cumulo 1000 broomstick, top speed 27mph!",
                            Image = "https://magicalgoodsblob.blob.core.windows.net/products/broom.jpeg",
                            Name = "Used Flying Broomstick",
                            Price = 1200.00m
                        },
                        new
                        {
                            ID = 3,
                            Description = "No, really, EVERY flavor!",
                            Image = "https://magicalgoodsblob.blob.core.windows.net/products/Bertie_Botts.png",
                            Name = "Every Flavor Jellybeans",
                            Price = 2.00m
                        },
                        new
                        {
                            ID = 4,
                            Description = "Chocolate Frog that really hops and has the card of a witch or wizard!",
                            Image = "https://magicalgoodsblob.blob.core.windows.net/products/frog.jpg",
                            Name = "Chocolate Frog",
                            Price = 1.50m
                        },
                        new
                        {
                            ID = 5,
                            Description = "Touch it to any question, and it will write the answer!",
                            Image = "https://magicalgoodsblob.blob.core.windows.net/products/Quill-lrg.png",
                            Name = "Auto-answer Quill",
                            Price = 500.00m
                        },
                        new
                        {
                            ID = 6,
                            Description = "A bag with considerably more space inside than it appears at first glance. Holds up to 500lbs, but only ever weighs 15!",
                            Image = "https://magicalgoodsblob.blob.core.windows.net/products/bag-of-holding.jpeg",
                            Name = "Bag of Holding",
                            Price = 400.00m
                        },
                        new
                        {
                            ID = 7,
                            Description = "Just press a button, and this rod will fix itself in place. Defy gravity!",
                            Image = "https://magicalgoodsblob.blob.core.windows.net/products/rod.jpeg",
                            Name = "Immovable Rod",
                            Price = 50.00m
                        },
                        new
                        {
                            ID = 8,
                            Description = "Magically transform into anyone with just a small piece of their hair!",
                            Image = "https://magicalgoodsblob.blob.core.windows.net/products/polyjuice.jpg",
                            Name = "Polyjuice Potion",
                            Price = 150.00m
                        },
                        new
                        {
                            ID = 9,
                            Description = "Put on these slippers, and walk on any surface!",
                            Image = "https://magicalgoodsblob.blob.core.windows.net/products/slippers.jpeg",
                            Name = "Slippers of Spider Climb",
                            Price = 250.00m
                        },
                        new
                        {
                            ID = 10,
                            Description = "A powerful wand with a core made from the feather of a pheonix",
                            Image = "https://magicalgoodsblob.blob.core.windows.net/products/wand.png",
                            Name = "Pheonix-core Wand",
                            Price = 1000.00m
                        });
                });

            modelBuilder.Entity("MagicalGoods.Models.CartProduct", b =>
                {
                    b.HasOne("MagicalGoods.Models.Cart", null)
                        .WithMany("CartProducts")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MagicalGoods.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MagicalGoods.Models.Order", b =>
                {
                    b.HasOne("MagicalGoods.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartID");
                });
#pragma warning restore 612, 618
        }
    }
}
