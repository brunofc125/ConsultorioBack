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
    public class PacienteController : ControllerBase
    {
        private IPacienteService pacienteService;
        public PacienteController(IPacienteService pacienteServiceParam)
        {
            this.pacienteService = pacienteServiceParam;
        }

        [HttpPost]
        public bool CadastrarPaciente([FromBody]PacienteViewModel pacienteViewModel)
        {
            return this.pacienteService.CadastrarPaciente(pacienteViewModel);
        }

        [Route("searchId")]
        [HttpGet]
        public PacienteViewModel obterPacienteId()
        {
            string id = Request.Query["id"];
            return this.pacienteService.GetPaciente(id);
        }

        [HttpDelete]
        public bool DeletarPaciente()
        {
            string id = Request.Query["id"];
            return this.pacienteService.DeletarPaciente(id);
        }

        [HttpPut]
        public bool AtualizarPaciente([FromBody] PacienteViewModel pacienteViewModel)
        {
            return this.pacienteService.AtualizarPaciente(pacienteViewModel);
        }

        [Route("search")]
        [HttpGet]
        public IEnumerable<PacienteViewModel> ObterPacientes()
        {
            var lista = this.pacienteService.ObterPacientes(Request.Query["nome"]);
            return lista;
        }

    }
}
