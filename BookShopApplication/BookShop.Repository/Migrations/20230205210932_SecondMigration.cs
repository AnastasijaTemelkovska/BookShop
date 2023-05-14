using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Repository.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookInShoppingCarts",
                table: "BookInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookInOrder",
                table: "BookInOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookInShoppingCarts",
                table: "BookInShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookInOrder",
                table: "BookInOrder",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookInShoppingCarts_BookId",
                table: "BookInShoppingCarts",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookInOrder_BookId",
                table: "BookInOrder",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookInShoppingCarts",
                table: "BookInShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_BookInShoppingCarts_BookId",
                table: "BookInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookInOrder",
                table: "BookInOrder");

            migrationBuilder.DropIndex(
                name: "IX_BookInOrder_BookId",
                table: "BookInOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookInShoppingCarts",
                table: "BookInShoppingCarts",
                columns: new[] { "BookId", "ShoppingCartId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookInOrder",
                table: "BookInOrder",
                columns: new[] { "BookId", "OrderId" });
        }
    }
}
