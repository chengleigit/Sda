using Microsoft.EntityFrameworkCore.Migrations;

namespace Sda.EntityFrameworkCore.Migrations
{
    public partial class RenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SDA",
                schema: "HREntitys",
                table: "SDA");

            migrationBuilder.EnsureSchema(
                name: "SDA");

            migrationBuilder.RenameTable(
                name: "SDA",
                schema: "HREntitys",
                newName: "HREntitys",
                newSchema: "SDA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HREntitys",
                schema: "SDA",
                table: "HREntitys",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HREntitys",
                schema: "SDA",
                table: "HREntitys");

            migrationBuilder.EnsureSchema(
                name: "HREntitys");

            migrationBuilder.RenameTable(
                name: "HREntitys",
                schema: "SDA",
                newName: "SDA",
                newSchema: "HREntitys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDA",
                schema: "HREntitys",
                table: "SDA",
                column: "Id");
        }
    }
}
