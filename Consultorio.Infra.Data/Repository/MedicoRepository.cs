using Consultorio.Domain.Entity;
using Consultorio.Domain.Repository;
using Consultorio.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consultorio.Infra.Data.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private ConsultorioContext context;
        public MedicoRepository(ConsultorioContext contextParam)
        {
            this.context = contextParam;
        }
        public bool AtualizarMedico(Medico medico)
        {
            this.context.Update(medico);
            return (this.context.SaveChanges() > 0);
        }

        public bool CadastrarMedico(Medico medico)
        {
            medico.Id = Guid.NewGuid();
            this.context.Add(medico);
            return (this.context.SaveChanges() > 0);
        }

        public bool DeletarMedico(Medico medico)
        {
            this.context.Remove(medico);
            return (this.context.SaveChanges() > 0);
        }

        public Medico GetMedico(string id)
        {
            Medico m = this.context.Set<Medico>().FirstOrDefault(x => x.Id.ToString() == id);
            return m;
        }

        public Medico GetMedicoCrm(Medico medico, bool atualizar)
        {
            if (atualizar)
            {
                return this.context.Set<Medico>().FirstOrDefault(x => x.Crm.Equals(medico.Crm) && x.Id != medico.Id);
            }
            else
            {
                return this.context.Set<Medico>().FirstOrDefault(x => x.Crm.Equals(medico.Crm));
            }
        }

        public IEnumerable<Medico> ObterMedicos(string valor)
        {
            var listaMedico = this.context.Set<Medico>().Where(x => x.Nome.Contains(valor) || x.Crm.Contains(valor)).OrderBy(x => x.Nome).ToList();
            return listaMedico;
        }
    }
}
