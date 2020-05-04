using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicalGoods.Migrations.StoreDb
{
    public partial class sprinttwodeploy : Migration
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
                    { 1, "A feather taken from an empty hippogryff nest that belonged to a young hippogriff!", "https://pm1.narvii.com/6511/68a4998e3c775db2e30db7aca026aadf997d34ca_hq.jpg", "Baby Hippogriff Feather", 100.00m },
                    { 2, "A 2018 Cumulo 1000 broomstick, top speed 27mph!", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/152/1000/1000/636284717908019789.jpeg", "Used Flying Broomstick", 1200.00m },
                    { 3, "No, really, EVERY flavor!", "https://vignette.wikia.nocookie.net/harrypotter/images/6/60/Bertie_Botts_EFB.png/revision/latest?cb=20161128010133", "Every Flavor Jellybeans", 2.00m },
                    { 4, "Chocolate Frog that really hops and has the card of a witch or wizard!", "https://images-na.ssl-images-amazon.com/images/I/91rOTxaOA3L._AC_SL1500_.jpg", "Chocolate Frog", 1.50m },
                    { 5, "Touch it to any question, and it will write the answer!", "https://img1.wikia.nocookie.net/__cb20121112222214/harrypotter/images/d/d0/Quill-lrg.png", "Auto-answer Quill", 500.00m },
                    { 6, "A bag with considerably more space inside than it appears at first glance. Holds up to 500lbs, but only ever weighs 15!", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/120/1000/1000/636284708068284913.jpeg", "Bag of Holding", 400.00m },
                    { 7, "Just press a button, and this rod will fix itself in place. Defy gravity!", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/261/1000/1000/636284741670235041.jpeg", "Immovable Rod", 50.00m },
                    { 8, "Magically transform into anyone with just a small piece of their hair!", "https://i.stack.imgur.com/LerE3.jpg", "Polyjuice Potion", 150.00m },
                    { 9, "Put on these slippers, and walk on any surface!", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/402/1000/1000/636284767446806965.jpeg", "Slippers of Spider Climb", 250.00m },
                    { 10, "A powerful wand with a core made from the feather of a pheonix", null, "Pheonix-core Wand", 1000.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_CartID",
                table: "CartProducts",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductID",
                table: "CartProducts",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
