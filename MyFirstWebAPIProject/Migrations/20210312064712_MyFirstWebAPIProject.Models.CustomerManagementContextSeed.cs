using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFirstWebAPIProject.Migrations
{
    public partial class MyFirstWebAPIProjectModelsCustomerManagementContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "IsOldCustomer", "Name", "Phone" },
                values: new object[] { 1, false, "Ram", "8861500156" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);
        }
    }
}
