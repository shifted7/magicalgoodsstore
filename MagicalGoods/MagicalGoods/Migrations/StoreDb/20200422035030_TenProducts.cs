using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicalGoods.Migrations.StoreDb
{
    public partial class TenProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 7, "Just press a button, and this rod will fix itself in place. Defy gravity!", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/261/1000/1000/636284741670235041.jpeg", "Immovable Rod", 50.00m },
                    { 8, "Magically transform into anyone with just a small piece of their hair!", "https://i.stack.imgur.com/LerE3.jpg", "Polyjuice Potion", 150.00m },
                    { 9, "Put on these slippers, and walk on any surface!", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/402/1000/1000/636284767446806965.jpeg", "Slippers of Spider Climb", 250.00m },
                    { 10, "A powerful wand with a core made from the feather of a pheonix", null, "Pheonix-core Wand", 1000.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10);
        }
    }
}
