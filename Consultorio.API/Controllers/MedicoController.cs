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
    public class MedicoController : ControllerBase
    {
        private IMedicoService medicoService;
        public MedicoController(IMedicoService medicoServiceParam)
        {
            this.medicoService = medicoServiceParam;
        }

        [HttpPost]
        public bool CadastrarMedico([FromBody] MedicoViewModel medicoViewModel)
        {
            return this.medicoService.CadastrarMedico(medicoViewModel);
        }

        [Route("searchId")]
        [HttpGet]
        public MedicoViewModel ObterMedicoId()
        {
            string id = Request.Query["id"];
            return this.medicoService.GetMedico(id);
        }

        [HttpDelete]
        public bool DeletarMedico()
        {
            string id = Request.Query["id"];
            return this.medicoService.DeletarMedico(id);
        }

        [HttpPut]
        public bool AtualizarMedico([FromBody] MedicoViewModel medicoViewModel)
        {
            return this.medicoService.AtualizarMedico(medicoViewModel);
        }

        [Route("search")]
        [HttpGet]
        public IEnumerable<MedicoViewModel> ObterMedicos()
        {
            var lista = this.medicoService.ObterMedicos(Request.Query["valor"]);
            return lista;
        }
    }
}
