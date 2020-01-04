using Consultorio.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Domain.Repository
{
    public interface IAgendamentoRepository
    {
        public bool CadastrarAgendamento(Agendamento agendamento);
        public Agendamento GetAgendamento(string id);
        public bool DeletarAgendamento(Agendamento agendamento);
        public bool AtualizarAgendamento(Agendamento agendamento);
        public IEnumerable<Agendamento> ObterAgendamentos(DateTime horario, bool todos);
        public IEnumerable<Agendamento> ObterAgendamentos(Agendamento agendamento, bool atualizar);
        public IEnumerable<Agendamento> ObterAgendamentos(string nome);

    }
}
