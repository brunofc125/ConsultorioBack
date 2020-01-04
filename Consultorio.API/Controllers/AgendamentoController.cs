using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Application.Service.Interface;
using Consultorio.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Consultorio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private IAgendamentoService agendamentoService;
        public AgendamentoController(IAgendamentoService agendamentoServiceParam)
        {
            this.agendamentoService = agendamentoServiceParam;
        }

        [HttpPost]
        public bool CadastrarAgendamento([FromBody]AgendamentoViewModel agendamentoViewModel)
        {
            return this.agendamentoService.CadastrarAgendamento(agendamentoViewModel);                            
        }

        [Route("searchId")]
        [HttpGet]
        public AgendamentoViewModelPaciente GetAgendamento()
        {
            string id = Request.Query["id"];
            return this.agendamentoService.GetAgendamentoPaciente(id);
        }

        [HttpDelete]
        public bool DeletarAgendamento()
        {
            string id = Request.Query["id"];
            return this.agendamentoService.DeletarAgendamento(id);
        }

        [HttpPut]
        public bool AtualizarAgendamento([FromBody] AgendamentoViewModel agendamentoViewModel)
        {
            return this.agendamentoService.AtualizarAgendamento(agendamentoViewModel);
        }

        [Route("search")]
        [HttpGet]
        public IEnumerable<AgendamentoViewModelPaciente> ObterAgendamentos()
        {
            string dateString = Request.Query["data"];
            var date = dateString.Equals("") ? new DateTime() : DateTime.Parse(dateString);
            var lista = this.agendamentoService.ObterAgendamentosPaciente(date, dateString.Equals(""));
            return lista;
        }

        [Route("searchNome")]
        [HttpGet]
        public IEnumerable<AgendamentoViewModelPaciente> ObterAgendamentosNome()
        {
            string nome = Request.Query["nomePaciente"];
            var lista = this.agendamentoService.ObterAgendamentosPaciente(nome);
            return lista;
        }
    }
}
