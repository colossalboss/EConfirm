using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EConfirm.Migrations
{
    public partial class RenameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswer_EmployeeEvaluations_EmployeeEvaluationId",
                table: "QuestionAnswer");

            migrationBuilder.DropColumn(
                name: "EvaluationId",
                table: "QuestionAnswer");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeEvaluationId",
                table: "QuestionAnswer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswer_EmployeeEvaluations_EmployeeEvaluationId",
                table: "QuestionAnswer",
                column: "EmployeeEvaluationId",
                principalTable: "EmployeeEvaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswer_EmployeeEvaluations_EmployeeEvaluationId",
                table: "QuestionAnswer");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeEvaluationId",
                table: "QuestionAnswer",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "EvaluationId",
                table: "QuestionAnswer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswer_EmployeeEvaluations_EmployeeEvaluationId",
                table: "QuestionAnswer",
                column: "EmployeeEvaluationId",
                principalTable: "EmployeeEvaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
