using Consultorio.Domain.Entity;
using Consultorio.Domain.Repository;
using Consultorio.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consultorio.Infra.Data.Repository
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private ConsultorioContext context;
        public AgendamentoRepository(ConsultorioContext contextParam)
        {
            this.context = contextParam;
        }
        public bool AtualizarAgendamento(Agendamento agendamento)
        {
            this.context.Update(agendamento);
            return (this.context.SaveChanges() > 0);
        }

        public bool CadastrarAgendamento(Agendamento agendamento)
        {
            agendamento.Id = Guid.NewGuid();
            this.context.Add(agendamento);
            return (this.context.SaveChanges() > 0);
        }

        public bool DeletarAgendamento(Agendamento agendamento)
        {
            this.context.Remove(agendamento);
            return (this.context.SaveChanges() > 0);
        }

        public Agendamento GetAgendamento(string id)
        {
            Agendamento a = this.context.Set<Agendamento>().FirstOrDefault(x => x.Id.ToString() == id);
            return a;
        }

        public IEnumerable<Agendamento> ObterAgendamentos(DateTime horario, bool todos)
        {
            IEnumerable<Agendamento> listaAgendamento;
            if (todos)
                listaAgendamento = this.context.Set<Agendamento>().OrderBy(x => x.HorarioInicial).ToList();
            else
                listaAgendamento = this.context.Set<Agendamento>().Where(x => x.HorarioInicial.Date.Equals(horario.Date)).OrderBy(x => x.HorarioInicial).ToList();
            return listaAgendamento;
        }

        public IEnumerable<Agendamento> ObterAgendamentos(string nome)
        {
            var listaAgendamento = this.context.Agendamento.Include(a => a.Paciente).Where(a => a.Paciente.Nome.Contains(nome)).OrderBy(x => x.HorarioInicial).ToList();
            return listaAgendamento;
        }

        public IEnumerable<Agendamento> ObterAgendamentos(Agendamento agendamento, bool atualizar)
        {
            DateTime hIni = agendamento.HorarioInicial;
            DateTime hFim = agendamento.HorarioFinal;
            IEnumerable<Agendamento> listaAgendamento;
            // verificar horario inicial
            if (atualizar)
            {
                listaAgendamento = this.context.Set<Agendamento>().Where(x =>
                    ((x.HorarioInicial.CompareTo(hIni) <= 0 && x.HorarioFinal.CompareTo(hIni) > 0) ||
                    (x.HorarioInicial.CompareTo(hFim) < 0 && x.HorarioFinal.CompareTo(hFim) >= 0) ||
                    (x.HorarioInicial.CompareTo(hIni) >= 0 && x.HorarioFinal.CompareTo(hFim) <= 0)) &&
                    x.Id != agendamento.Id
                ).ToList();
            }
            else
            {
                listaAgendamento = this.context.Set<Agendamento>().Where(x =>
                    (x.HorarioInicial.CompareTo(hIni) <= 0 && x.HorarioFinal.CompareTo(hIni) > 0) ||
                    (x.HorarioInicial.CompareTo(hFim) < 0 && x.HorarioFinal.CompareTo(hFim) >= 0) ||
                    (x.HorarioInicial.CompareTo(hIni) >= 0 && x.HorarioFinal.CompareTo(hFim) <= 0)
                ).ToList();
            }

            return listaAgendamento;
        }
    }
}
