using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Application.ViewModel
{
    public class PacienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public PacienteViewModel()
        {

        }
        public PacienteViewModel(Guid id, string nome, DateTime dataNasc)
        {
            this.Id = id;
            this.Nome = nome;
            this.DataNasc = dataNasc;
        }
        public PacienteViewModel(string nome, DateTime dataNasc)
        {
            this.Nome = nome;
            this.DataNasc = dataNasc;
        }
    }
}
