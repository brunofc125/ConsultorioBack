using Consultorio.Application.Service.Interface;
using Consultorio.Application.ViewModel;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consultorio.Application.Service
{
    public class AgendamentoService : IAgendamentoService
    {
        private IAgendamentoRepository agendamentoRepository;
        private IPacienteRepository pacienteRepository;
        public AgendamentoService(IAgendamentoRepository agendamentoRepositoryParam, IPacienteRepository pacienteRepositoryParam)
        {
            this.agendamentoRepository = agendamentoRepositoryParam;
            this.pacienteRepository = pacienteRepositoryParam;
        }
        public bool AtualizarAgendamento(AgendamentoViewModel agendamento)
        {
            var a = new Agendamento(agendamento.Id, agendamento.IdUsuario, agendamento.IdPaciente, agendamento.HorarioInicial, agendamento.HorarioFinal, agendamento.Observacao);
            if (a.HorarioInicial.CompareTo(a.HorarioFinal) <= 0)
            {
                if (this.agendamentoRepository.ObterAgendamentos(a, true).Count() == 0)
                {
                    return this.agendamentoRepository.AtualizarAgendamento(a);
                }
            }
            return false;
        }

        public bool CadastrarAgendamento(AgendamentoViewModel agendamento)
        {
            var a = new Agendamento(agendamento.Id, agendamento.IdUsuario, agendamento.IdPaciente, agendamento.HorarioInicial, agendamento.HorarioFinal, agendamento.Observacao);
            if (a.HorarioInicial.CompareTo(a.HorarioFinal) <= 0 && this.agendamentoRepository.ObterAgendamentos(a, false).Count() == 0)
            {
                return this.agendamentoRepository.CadastrarAgendamento(a);
            }
            return false;
        }

        public bool DeletarAgendamento(string id)
        {
            var a = this.agendamentoRepository.GetAgendamento(id);
            if(a != null)
                return this.agendamentoRepository.DeletarAgendamento(a);
            return false;
        }

        public AgendamentoViewModel GetAgendamento(string id)
        {
            var a = this.agendamentoRepository.GetAgendamento(id);
            if (a != null)
                return new AgendamentoViewModel(a.Id, a.IdUsuario, a.IdPaciente, a.HorarioInicial, a.HorarioFinal, a.Observacao);
            return null;
        }

        public AgendamentoViewModelPaciente GetAgendamentoPaciente(string id)
        {
            var a = this.agendamentoRepository.GetAgendamento(id);
            var p = this.pacienteRepository.GetPaciente(a.IdPaciente.ToString());
            var pac = new PacienteViewModel(p.Id, p.Nome, p.DataNasc);
            if (a != null && p!= null)
                return new AgendamentoViewModelPaciente(a.Id, a.IdUsuario, a.IdPaciente, a.HorarioInicial, a.HorarioFinal, a.Observacao, pac);
            return null;
        }

        public IEnumerable<AgendamentoViewModel> ObterAgendamentos(DateTime horario, bool todos)
        {
            var listaAgendamento = this.agendamentoRepository.ObterAgendamentos(horario, todos);
            var listaAgendamentoViewModel = new List<AgendamentoViewModel>();
            foreach (var a in listaAgendamento)
            {
                var aViewModel = new AgendamentoViewModel(a.Id, a.IdUsuario, a.IdPaciente, a.HorarioInicial, a.HorarioFinal, a.Observacao);
                listaAgendamentoViewModel.Add(aViewModel);
            }
            return listaAgendamentoViewModel;
        }

        public IEnumerable<AgendamentoViewModelPaciente> ObterAgendamentosPaciente(DateTime horario, bool todos)
        {
            var listaAgendamento = this.agendamentoRepository.ObterAgendamentos(horario, todos);
            var listaAgendamentoViewModelPaciente = new List<AgendamentoViewModelPaciente>();
            foreach (var a in listaAgendamento)
            {
                var p = this.pacienteRepository.GetPaciente(a.IdPaciente.ToString());
                var pac = new PacienteViewModel(p.Id, p.Nome, p.DataNasc);
                var aViewModel = new AgendamentoViewModelPaciente(a.Id, a.IdUsuario, a.IdPaciente, a.HorarioInicial, a.HorarioFinal, a.Observacao, pac);
                listaAgendamentoViewModelPaciente.Add(aViewModel);
            }
            return listaAgendamentoViewModelPaciente;
        }

        public IEnumerable<AgendamentoViewModelPaciente> ObterAgendamentosPaciente()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AgendamentoViewModelPaciente> ObterAgendamentosPaciente(string nome)
        {
            var listaAgendamento = this.agendamentoRepository.ObterAgendamentos(nome);
            var listaAgendamentoViewModelPaciente = new List<AgendamentoViewModelPaciente>();
            foreach (var a in listaAgendamento)
            {
                var pac = new PacienteViewModel(a.Paciente.Id, a.Paciente.Nome, a.Paciente.DataNasc);
                var aViewModel = new AgendamentoViewModelPaciente(a.Id, a.IdUsuario, a.IdPaciente, a.HorarioInicial, a.HorarioFinal, a.Observacao, pac);
                listaAgendamentoViewModelPaciente.Add(aViewModel);
            }
            return listaAgendamentoViewModelPaciente;
        }
    }
}
