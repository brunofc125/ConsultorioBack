using Consultorio.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Application.Service.Interface
{
    public interface IPacienteService
    {
        public bool CadastrarPaciente(PacienteViewModel paciente);
        public PacienteViewModel GetPaciente(string id);
        public bool DeletarPaciente(string id);
        public bool AtualizarPaciente(PacienteViewModel paciente);
        public IEnumerable<PacienteViewModel> ObterPacientes(string nome);
    }
}
