using Microsoft.EntityFrameworkCore.Migrations;

namespace Order_Management.Migrations
{
    public partial class AlterCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "TelNo",
                table: "Tokens");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Customers",
                maxLength: 12,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Tokens",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelNo",
                table: "Tokens",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
