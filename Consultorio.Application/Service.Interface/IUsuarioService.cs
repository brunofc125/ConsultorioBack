using Consultorio.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Application.Service.Interface
{
    public interface IUsuarioService
    {
        public bool CadastrarUsuario(UsuarioViewModel usuarioViewModel);
        public UsuarioViewModel GetUsuario(string login, string senha);
        public UsuarioViewModel GetUsuario(string id);
        public IEnumerable<UsuarioViewModel> ObterUsuarios(string nome);
        public bool DeletarUsuario(string id);
        public bool AtualizarUsuario(UsuarioViewModel usuario);
    }
}
