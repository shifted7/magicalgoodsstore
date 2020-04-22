using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicalGoods.Migrations.StoreDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 6, "A bag with considerably more space inside than it appears at first glance. Holds up to 500lbs, but only ever weighs 15!", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/120/1000/1000/636284708068284913.jpeg", "Bag of Holding", 400.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
