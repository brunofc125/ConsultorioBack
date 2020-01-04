using Consultorio.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Domain.Repository
{
    public interface IPacienteRepository
    {
        public bool CadastrarPaciente(Paciente paciente);
        public Paciente GetPaciente(string id);
        public bool DeletarPaciente(Paciente paciente);
        public bool AtualizarPaciente(Paciente paciente);
        public IEnumerable<Paciente> ObterPacientes(string nome);
    }
}
