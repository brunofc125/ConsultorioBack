using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorio.Infra.Data.Migrations.Migrations
{
    public partial class onDeleteCascadeUsuarioAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Usuario_IdUsuario",
                table: "Agendamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Usuario_IdUsuario",
                table: "Agendamento",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Usuario_IdUsuario",
                table: "Agendamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Usuario_IdUsuario",
                table: "Agendamento",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
