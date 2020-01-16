using Consultorio.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Domain.Repository
{
    public interface IMedicoRepository
    {
        public bool CadastrarMedico(Medico medico);
        public Medico GetMedico(string id);
        public Medico GetMedicoCrm(Medico medico, bool atualizar);
        public bool DeletarMedico(Medico medico);
        public bool AtualizarMedico(Medico medico);
        public IEnumerable<Medico> ObterMedicos(string valor);
    }
}
