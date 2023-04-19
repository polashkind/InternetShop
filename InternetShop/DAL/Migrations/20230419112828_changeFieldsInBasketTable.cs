using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeFieldsInBasketTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "To_pay",
                table: "Baskets",
                newName: "TotalBasketPrice");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Baskets",
                newName: "Count");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalBasketPrice",
                table: "Baskets",
                newName: "To_pay");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Baskets",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Baskets",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
