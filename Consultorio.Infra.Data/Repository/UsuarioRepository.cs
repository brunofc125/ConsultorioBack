using Consultorio.Domain.Entity;
using Consultorio.Domain.Repository;
using Consultorio.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consultorio.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ConsultorioContext context;
        public UsuarioRepository(ConsultorioContext contextParam)
        {
            this.context = contextParam;
        }
        public bool AtualizarUsuario(Usuario usuario)
        {
            this.context.Update(usuario);
            return (this.context.SaveChanges() > 0);
        }

        public bool CadastrarUsuario(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            this.context.Add(usuario);
            return (this.context.SaveChanges() > 0);
        }

        public bool DeletarUsuario(Usuario usuario)
        {
            this.context.Remove(usuario);
            return (this.context.SaveChanges() > 0);
        }

        public Usuario GetUsuario(string id)
        {
            Usuario u = this.context.Set<Usuario>().FirstOrDefault(x => x.Id.ToString() == id);
            return u;
        }

        public Usuario GetUsuario(string login, string senha)
        {
            Usuario u = this.context.Set<Usuario>().FirstOrDefault(x => x.Login == login && x.Senha == senha);
            return u;
        }

        public Usuario GetUsuarioLogin(string login)
        {
            Usuario u = this.context.Set<Usuario>().FirstOrDefault(x => x.Login == login);
            return u;
        }

        public IEnumerable<Usuario> ObterUsuarios(string nome)
        {
            var listaUsuario = this.context.Set<Usuario>().Where(x => x.Nome.Contains(nome)).ToList();
            return listaUsuario;
        }
    }
}
