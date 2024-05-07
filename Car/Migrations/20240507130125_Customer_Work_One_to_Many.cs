using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car.Migrations
{
    /// <inheritdoc />
    public partial class Customer_Work_One_to_Many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Works_CustomerId",
                table: "Works");

            migrationBuilder.CreateIndex(
                name: "IX_Works_CustomerId",
                table: "Works",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Works_CustomerId",
                table: "Works");

            migrationBuilder.CreateIndex(
                name: "IX_Works_CustomerId",
                table: "Works",
                column: "CustomerId",
                unique: true);
        }
    }
}
