using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class BankNombre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "BankEntities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "BankEntities");
        }
    }
}
