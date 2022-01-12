using Microsoft.EntityFrameworkCore.Migrations;

namespace Sda.EntityFrameworkCore.Migrations
{
    public partial class updateHREntityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HREntitys",
                table: "HREntitys");

            migrationBuilder.EnsureSchema(
                name: "HREntitys");

            migrationBuilder.RenameTable(
                name: "HREntitys",
                newName: "SDA",
                newSchema: "HREntitys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDA",
                schema: "HREntitys",
                table: "SDA",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SDA",
                schema: "HREntitys",
                table: "SDA");

            migrationBuilder.RenameTable(
                name: "SDA",
                schema: "HREntitys",
                newName: "HREntitys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HREntitys",
                table: "HREntitys",
                column: "Id");
        }
    }
}
