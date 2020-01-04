using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorio.Infra.Data.Migrations.Migrations
{
    public partial class onDeleteCascadePacienteAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Paciente_IdPaciente",
                table: "Agendamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Paciente_IdPaciente",
                table: "Agendamento",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Paciente_IdPaciente",
                table: "Agendamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Paciente_IdPaciente",
                table: "Agendamento",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
