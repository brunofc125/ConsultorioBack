using Consultorio.Domain.Entity;
using Consultorio.Domain.Repository;
using Consultorio.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consultorio.Infra.Data.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private ConsultorioContext context;
        public PacienteRepository(ConsultorioContext contextParam)
        {
            this.context = contextParam;
        }
        public bool AtualizarPaciente(Paciente paciente)
        {
            this.context.Update(paciente);
            return (this.context.SaveChanges() > 0);
        }

        public bool CadastrarPaciente(Paciente paciente)
        {
            paciente.Id = Guid.NewGuid();
            this.context.Add(paciente);
            return (this.context.SaveChanges() > 0);
        }

        public bool DeletarPaciente(Paciente paciente)
        {
            this.context.Remove(paciente);
            return (this.context.SaveChanges() > 0);
        }

        public Paciente GetPaciente(string id)
        {
            Paciente p = this.context.Set<Paciente>().FirstOrDefault(x => x.Id.ToString() == id);
            return p;
        }

        public IEnumerable<Paciente> ObterPacientes(string nome)
        {
            var listaPaciente = this.context.Set<Paciente>().Where(x => x.Nome.Contains(nome)).OrderBy(x => x.Nome).ToList();
            return listaPaciente;
        }
    }
}
