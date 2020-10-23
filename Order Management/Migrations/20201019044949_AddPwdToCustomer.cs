using Microsoft.EntityFrameworkCore.Migrations;

namespace Order_Management.Migrations
{
    public partial class AddPwdToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Customers");
        }
    }
}
