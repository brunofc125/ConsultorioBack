using Consultorio.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Application.Service.Interface
{
    public interface IMedicoService
    {
        public bool CadastrarMedico(MedicoViewModel medico);
        public MedicoViewModel GetMedico(string id);
        public bool DeletarMedico(string id);
        public bool AtualizarMedico(MedicoViewModel medico);
        public IEnumerable<MedicoViewModel> ObterMedicos(string valor);
    }
}
