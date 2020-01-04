using Consultorio.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Domain.Repository
{
    public interface IUsuarioRepository
    {
        public bool CadastrarUsuario(Usuario usuario);
        public Usuario GetUsuario(string id);
        public Usuario GetUsuario(string login, string senha);
        public Usuario GetUsuarioLogin(string login);
        public bool DeletarUsuario(Usuario usuario);
        public bool AtualizarUsuario(Usuario usuario);
        public IEnumerable<Usuario> ObterUsuarios(string nome);

    }
}
