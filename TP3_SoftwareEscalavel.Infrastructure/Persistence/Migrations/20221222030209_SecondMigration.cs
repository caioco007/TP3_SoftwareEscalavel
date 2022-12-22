using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3_SoftwareEscalavel.Infrastructure.Persistence.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtividadeAlunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAtividade = table.Column<int>(type: "int", nullable: false),
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "Date", nullable: false),
                    Nota = table.Column<decimal>(type: "decimal", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadeAlunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDisciplina = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicioEntrega = table.Column<DateTime>(type: "Date", nullable: false),
                    DataFinalEntrega = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeAlunos_IdAtividade_IdAluno",
                table: "AtividadeAlunos",
                columns: new[] { "IdAtividade", "IdAluno" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadeAlunos");

            migrationBuilder.DropTable(
                name: "Atividades");
        }
    }
}
