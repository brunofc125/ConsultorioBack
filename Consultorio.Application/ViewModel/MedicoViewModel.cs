using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Application.ViewModel
{
    public class MedicoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string Crm { get; set; }
        public MedicoViewModel()
        {

        }
        public MedicoViewModel(Guid id, string nome, DateTime dataNasc, string crm)
        {
            Id = id;
            Nome = nome;
            DataNasc = dataNasc;
            Crm = crm;
        }
        public MedicoViewModel(string nome, DateTime dataNasc, string crm)
        {
            Nome = nome;
            DataNasc = dataNasc;
            Crm = crm;
        }
    }
}
