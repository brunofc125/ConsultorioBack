using Consultorio.Application.Service.Interface;
using Consultorio.Application.ViewModel;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Application.Service
{
    public class MedicoService : IMedicoService
    {
        private IMedicoRepository medicoRepository;
        public MedicoService(IMedicoRepository medicoRepositoryParam)
        {
            this.medicoRepository = medicoRepositoryParam;
        }
        public bool AtualizarMedico(MedicoViewModel medico)
        {
            var m = new Medico(medico.Id, medico.Nome, medico.DataNasc, medico.Crm);
            var mCrm = this.medicoRepository.GetMedicoCrm(m, true);
            if(mCrm == null)
            {
                return this.medicoRepository.AtualizarMedico(m);
            }
            return false;
        }

        public bool CadastrarMedico(MedicoViewModel medico)
        {
            var m = new Medico(medico.Id, medico.Nome, medico.DataNasc, medico.Crm);
            var mCrm = this.medicoRepository.GetMedicoCrm(m, false);
            if (mCrm == null)
            {
                return this.medicoRepository.CadastrarMedico(m);
            }
            return false;
        }

        public bool DeletarMedico(string id)
        {
            var m = this.medicoRepository.GetMedico(id);
            if(m != null)
            {
                return this.medicoRepository.DeletarMedico(m);
            }
            return false;
        }

        public MedicoViewModel GetMedico(string id)
        {
            var m = this.medicoRepository.GetMedico(id);
            if(m != null)
            {
                return new MedicoViewModel(m.Id, m.Nome, m.DataNasc, m.Crm);
            }
            return null;
        }

        public IEnumerable<MedicoViewModel> ObterMedicos(string valor)
        {
            var listaMedico = this.medicoRepository.ObterMedicos(valor);
            var listaMedicoViewModel = new List<MedicoViewModel>();
            foreach (var m in listaMedico)
            {
                var mViewModel = new MedicoViewModel(m.Id, m.Nome, m.DataNasc, m.Crm);
                listaMedicoViewModel.Add(mViewModel);
            }
            return listaMedicoViewModel;
        }
    }
}
