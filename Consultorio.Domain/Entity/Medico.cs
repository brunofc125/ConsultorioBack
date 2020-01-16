using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Domain.Entity
{
    public class Medico
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string Crm { get; set; }
        public List<Agendamento> Agendamentos { get; set; }

        public Medico(Guid id, string nome, DateTime dataNasc, string crm)
        {
            Id = id;
            Nome = nome;
            DataNasc = dataNasc;
            Crm = crm;
        }

        public Medico(string nome, DateTime dataNasc, string crm)
        {
            Nome = nome;
            DataNasc = dataNasc;
            Crm = crm;
        }
    }
}
