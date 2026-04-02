using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salary",
                table: "Employees",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "Iob",
                table: "Employees",
                newName: "Job");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Employees",
                newName: "salary");

            migrationBuilder.RenameColumn(
                name: "Job",
                table: "Employees",
                newName: "Iob");
        }
    }
}
