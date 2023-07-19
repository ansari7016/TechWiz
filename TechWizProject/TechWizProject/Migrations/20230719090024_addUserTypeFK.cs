using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechWizProject.Migrations
{
    public partial class addUserTypeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registers_UserTypeId",
                table: "Registers",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_UserType_UserTypeId",
                table: "Registers",
                column: "UserTypeId",
                principalTable: "UserType",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registers_UserType_UserTypeId",
                table: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_Registers_UserTypeId",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "Registers");
        }
    }
}
