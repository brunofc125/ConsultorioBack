using Consultorio.Application.Service.Interface;
using Consultorio.Application.ViewModel;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Application.Service
{
    public class PacienteService : IPacienteService
    {
        private IPacienteRepository pacienteRepository;
        public PacienteService(IPacienteRepository pacienteRepositoryParam)
        {
            this.pacienteRepository = pacienteRepositoryParam;
        }
        public bool AtualizarPaciente(PacienteViewModel paciente)
        {
            return this.pacienteRepository.AtualizarPaciente(new Paciente(paciente.Id, paciente.Nome, paciente.DataNasc));
        }

        public bool CadastrarPaciente(PacienteViewModel paciente)
        {
            return this.pacienteRepository.CadastrarPaciente(new Paciente(paciente.Nome, paciente.DataNasc));
        }

        public bool DeletarPaciente(string id)
        {
            var p = this.pacienteRepository.GetPaciente(id);
            if(p != null)
                return this.pacienteRepository.DeletarPaciente(p);
            return false;
        }

        public PacienteViewModel GetPaciente(string id)
        {
            Paciente p = this.pacienteRepository.GetPaciente(id);
            if (p != null)
                return new PacienteViewModel(p.Id, p.Nome, p.DataNasc);
            return null;
        }

        public IEnumerable<PacienteViewModel> ObterPacientes(string nome)
        {
            var listaPaciente = this.pacienteRepository.ObterPacientes(nome);
            var listaPacienteViewModel = new List<PacienteViewModel>();
            foreach(var p in listaPaciente)
            {
                var pViewModel = new PacienteViewModel(p.Id, p.Nome, p.DataNasc);
                listaPacienteViewModel.Add(pViewModel);
            }
            return listaPacienteViewModel;
        }
    }
}
