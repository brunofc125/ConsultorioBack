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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService usuarioService;
        public UsuarioController(IUsuarioService usuarioServiceParam)
        {
            this.usuarioService = usuarioServiceParam;
        }

        [HttpPost]
        public bool CadastrarUsuario([FromBody]UsuarioViewModel usuarioViewModel)
        {
            return this.usuarioService.CadastrarUsuario(usuarioViewModel);
        }

        [Route("validar")]
        [HttpGet]
        public UsuarioViewModel ValidarUsuario()
        {
            string login = Request.Query["login"],
                   senha = Request.Query["senha"];
            return this.usuarioService.GetUsuario(login, senha);
        }

        [Route("search")]
        [HttpGet]
        public IEnumerable<UsuarioViewModel> ObterUsuarios()
        {
            var lista = this.usuarioService.ObterUsuarios(Request.Query["nome"]);
            return lista;
        }

        [Route("searchId")]
        [HttpGet]
        public UsuarioViewModel obterUsuarioId()
        {
            string id = Request.Query["id"];
            return this.usuarioService.GetUsuario(id);
        }

        [HttpDelete]
        public bool DeletarUsuario()
        {
            string id = Request.Query["id"];
            return this.usuarioService.DeletarUsuario(id);
        }

        [HttpPut]
        public bool AtualizarUsuario([FromBody] UsuarioViewModel usuarioViewModel)
        {
            return this.usuarioService.AtualizarUsuario(usuarioViewModel);
        }
    }
}
