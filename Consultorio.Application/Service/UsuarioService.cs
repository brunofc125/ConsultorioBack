using Consultorio.Application.Service.Interface;
using Consultorio.Application.ViewModel;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Application.Service
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepositoryParam)
        {
            this.usuarioRepository = usuarioRepositoryParam;
        }

        public bool CadastrarUsuario(UsuarioViewModel usuarioViewModel)
        {
            Usuario u = this.usuarioRepository.GetUsuarioLogin(usuarioViewModel.Login);
            if (u == null)
            {
                if(this.usuarioRepository.CadastrarUsuario(new Usuario(usuarioViewModel.Nome, usuarioViewModel.Login, usuarioViewModel.Senha)) )
                    return true;
            }
            return false;
        }

        public UsuarioViewModel GetUsuario(string login, string senha)
        {
            Usuario u = this.usuarioRepository.GetUsuario(login, senha);
            if (u != null)
                return new UsuarioViewModel(u.Id, u.Nome, u.Login, u.Senha);
            return null;
        }

        public UsuarioViewModel GetUsuario(string id)
        {
            Usuario u = this.usuarioRepository.GetUsuario(id);
            if (u != null)
                return new UsuarioViewModel(u.Id, u.Nome, u.Login, u.Senha);
            return null;
        }

        public IEnumerable<UsuarioViewModel> ObterUsuarios(string nome)
        {
            var listaUsuario = this.usuarioRepository.ObterUsuarios(nome);
            var listaUsuarioViewModel = new List<UsuarioViewModel>();
            foreach(var user in listaUsuario)
            {
                var userViewModel = new UsuarioViewModel(user.Id, user.Nome, user.Login, user.Senha);
                listaUsuarioViewModel.Add(userViewModel);
            }
            return listaUsuarioViewModel;
        }

        public bool DeletarUsuario(string id)
        {
            var u = this.usuarioRepository.GetUsuario(id);
            if(u != null)
                return this.usuarioRepository.DeletarUsuario(u);
            return false;
        }

        public bool AtualizarUsuario(UsuarioViewModel usuario)
        {
            return this.usuarioRepository.AtualizarUsuario(new Usuario(usuario.Id, usuario.Nome, usuario.Login, usuario.Senha));
        }
    }
}