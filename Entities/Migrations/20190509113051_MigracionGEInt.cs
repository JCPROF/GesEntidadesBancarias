using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class MigracionGEInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupEntities",
                columns: table => new
                {
                    GroupEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEntities", x => x.GroupEntityId);
                });

            migrationBuilder.CreateTable(
                name: "BankEntities",
                columns: table => new
                {
                    BankEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Direccion = table.Column<string>(nullable: true),
                    Poblacion = table.Column<string>(nullable: true),
                    Provincia = table.Column<string>(nullable: true),
                    CodPostal = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    LogoURL = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Estado_Activo = table.Column<bool>(nullable: false),
                    GroupEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankEntities", x => x.BankEntityId);
                    table.ForeignKey(
                        name: "FK_BankEntities_GroupEntities_GroupEntityId",
                        column: x => x.GroupEntityId,
                        principalTable: "GroupEntities",
                        principalColumn: "GroupEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankEntities_GroupEntityId",
                table: "BankEntities",
                column: "GroupEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankEntities");

            migrationBuilder.DropTable(
                name: "GroupEntities");
        }
    }
}
