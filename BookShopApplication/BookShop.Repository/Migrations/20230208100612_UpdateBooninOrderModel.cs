using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Repository.Migrations
{
    public partial class UpdateBooninOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BookInOrder",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BookInOrder");
        }
    }
}
