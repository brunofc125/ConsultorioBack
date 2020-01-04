using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Application.ViewModel
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public UsuarioViewModel()
        {

        }
        public UsuarioViewModel(Guid id, string nome, string login, string senha)
        {
            this.Id = id;
            this.Nome = nome;
            this.Login = login;
            this.Senha = senha;
        }
        public UsuarioViewModel(string nome, string login, string senha)
        {
            this.Nome = nome;
            this.Login = login;
            this.Senha = senha;
        }
    }
}
