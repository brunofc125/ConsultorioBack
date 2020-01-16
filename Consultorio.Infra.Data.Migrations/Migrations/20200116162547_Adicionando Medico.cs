using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorio.Infra.Data.Migrations.Migrations
{
    public partial class AdicionandoMedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdMedico",
                table: "Agendamento",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    Crm = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdMedico",
                table: "Agendamento",
                column: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Medico_IdMedico",
                table: "Agendamento",
                column: "IdMedico",
                principalTable: "Medico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Medico_IdMedico",
                table: "Agendamento");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_IdMedico",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "IdMedico",
                table: "Agendamento");
        }
    }
}
