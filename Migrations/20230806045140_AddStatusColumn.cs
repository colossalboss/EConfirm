using Microsoft.EntityFrameworkCore.Migrations;

namespace EConfirm.Migrations
{
    public partial class AddStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptedByEmployee",
                table: "EmployeeEvaluations");

            migrationBuilder.DropColumn(
                name: "SeenByEmployee",
                table: "EmployeeEvaluations");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "EmployeeEvaluations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "EmployeeEvaluations");

            migrationBuilder.AddColumn<bool>(
                name: "AcceptedByEmployee",
                table: "EmployeeEvaluations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SeenByEmployee",
                table: "EmployeeEvaluations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
