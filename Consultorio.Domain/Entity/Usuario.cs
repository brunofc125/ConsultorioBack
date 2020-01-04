using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Domain.Entity
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
        public Usuario(Guid id, string nome, string login, string senha)
        {
            this.Id = id;
            this.Nome = nome;
            this.Login = login;
            this.Senha = senha;
        }
        public Usuario(string nome, string login, string senha)
        {
            this.Nome = nome;
            this.Login = login;
            this.Senha = senha;
        }

    }
}
