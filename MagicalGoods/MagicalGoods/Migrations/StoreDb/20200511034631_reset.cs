using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicalGoods.Migrations.StoreDb
{
    public partial class reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    DateOfOrder = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    CartID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "A feather taken from an empty hippogryff nest that belonged to a young hippogriff!", "https://magicalgoodsblob.blob.core.windows.net/products/Quill.jpg", "Baby Hippogriff Feather", 100.00m },
                    { 2, "A 2018 Cumulo 1000 broomstick, top speed 27mph!", "https://magicalgoodsblob.blob.core.windows.net/products/broom.jpeg", "Used Flying Broomstick", 1200.00m },
                    { 3, "No, really, EVERY flavor!", "https://magicalgoodsblob.blob.core.windows.net/products/Bertie_Botts.png", "Every Flavor Jellybeans", 2.00m },
                    { 4, "Chocolate Frog that really hops and has the card of a witch or wizard!", "https://magicalgoodsblob.blob.core.windows.net/products/frog.jpg", "Chocolate Frog", 1.50m },
                    { 5, "Touch it to any question, and it will write the answer!", "https://magicalgoodsblob.blob.core.windows.net/products/Quill-lrg.png", "Auto-answer Quill", 500.00m },
                    { 6, "A bag with considerably more space inside than it appears at first glance. Holds up to 500lbs, but only ever weighs 15!", "https://magicalgoodsblob.blob.core.windows.net/products/bag-of-holding.jpeg", "Bag of Holding", 400.00m },
                    { 7, "Just press a button, and this rod will fix itself in place. Defy gravity!", "https://magicalgoodsblob.blob.core.windows.net/products/rod.jpeg", "Immovable Rod", 50.00m },
                    { 8, "Magically transform into anyone with just a small piece of their hair!", "https://magicalgoodsblob.blob.core.windows.net/products/polyjuice.jpg", "Polyjuice Potion", 150.00m },
                    { 9, "Put on these slippers, and walk on any surface!", "https://magicalgoodsblob.blob.core.windows.net/products/slippers.jpeg", "Slippers of Spider Climb", 250.00m },
                    { 10, "A powerful wand with a core made from the feather of a pheonix", "https://magicalgoodsblob.blob.core.windows.net/products/wand.png", "Pheonix-core Wand", 1000.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_CartID",
                table: "CartProducts",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductID",
                table: "CartProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartID",
                table: "Orders",
                column: "CartID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
