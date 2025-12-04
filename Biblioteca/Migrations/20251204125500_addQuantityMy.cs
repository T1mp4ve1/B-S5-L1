using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class addQuantityMy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "BookS");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BookS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BookS");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "BookS",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
