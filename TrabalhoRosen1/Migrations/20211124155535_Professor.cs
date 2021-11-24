using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabalhoRosen1.Migrations
{
    public partial class Professor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<long>(type: "bigint", nullable: true),
                    MateriaEscolarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professores_MateriaEscolares_MateriaEscolarId",
                        column: x => x.MateriaEscolarId,
                        principalTable: "MateriaEscolares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professores_MateriaEscolarId",
                table: "Professores",
                column: "MateriaEscolarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
