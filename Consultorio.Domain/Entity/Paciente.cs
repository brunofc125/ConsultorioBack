using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Domain.Entity
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
        public Paciente(Guid id, string nome, DateTime dataNasc)
        {
            this.Id = id;
            this.Nome = nome;
            this.DataNasc = dataNasc;
        }
        public Paciente(string nome, DateTime dataNasc)
        {
            this.Nome = nome;
            this.DataNasc = dataNasc;
        }
    }
}
