using Consultorio.Application.Service;
using Consultorio.Application.ViewModel;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Consultorio.Test
{
    public class PacienteTest
    {
        //[metodo]_[condicao]_[ResultadoEsperado]

        private readonly Mock<IPacienteRepository> pacienteRepositoryMock;
        public PacienteTest()
        {
            this.pacienteRepositoryMock = new Mock<IPacienteRepository>();
        }

        [Fact]
        public void AtualizarPaciente_TerPaciente_RetornarTrue()
        {
            // arrange
            var pac = new PacienteViewModel(Guid.NewGuid(), "BrunoAlterado", DateTime.Now);
            this.pacienteRepositoryMock.Setup(r => r.AtualizarPaciente(It.IsAny<Paciente>())).Returns(true);
            var pacienteService = new PacienteService(this.pacienteRepositoryMock.Object);

            // act
            var test = pacienteService.AtualizarPaciente(pac);

            // assert
            Assert.True(test);
        }

        [Fact]
        public void AtualizarPaciente_TerPaciente_RetornarFalse()
        {
            // arrange
            var pac = new PacienteViewModel(Guid.NewGuid(), "BrunoAlterado", DateTime.Now);
            this.pacienteRepositoryMock.Setup(r => r.AtualizarPaciente(It.IsAny<Paciente>())).Returns(false);
            var pacienteService = new PacienteService(this.pacienteRepositoryMock.Object);

            // act
            var test = pacienteService.AtualizarPaciente(pac);

            // assert
            Assert.False(test);
        }

        [Fact]
        public void CadastrarPaciente_TerPaciente_RetornarTrue()
        {
            // arrange
            var pac = new PacienteViewModel(Guid.NewGuid(), "Bruno", DateTime.Now);
            this.pacienteRepositoryMock.Setup(r => r.CadastrarPaciente(It.IsAny<Paciente>())).Returns(true);
            var pacienteService = new PacienteService(this.pacienteRepositoryMock.Object);

            // act
            var test = pacienteService.CadastrarPaciente(pac);

            // assert
            Assert.True(test);
        }

        [Fact]
        public void CadastrarPaciente_TerPaciente_RetornarFalse()
        {
            // arrange
            var pac = new PacienteViewModel(Guid.NewGuid(), "Bruno", DateTime.Now);
            this.pacienteRepositoryMock.Setup(r => r.CadastrarPaciente(It.IsAny<Paciente>())).Returns(false);
            var pacienteService = new PacienteService(this.pacienteRepositoryMock.Object);

            // act
            var test = pacienteService.CadastrarPaciente(pac);

            // assert
            Assert.False(test);
        }

        [Fact]
        public void DeletarPaciente_PeloId_RetornarTrue()
        {
            // arrange
            Guid id = Guid.NewGuid();
            Paciente p = new Paciente(id, "Bruno", DateTime.Parse("1999-03-13"));
            this.pacienteRepositoryMock.Setup(r => r.GetPaciente(id.ToString())).Returns(p);
            this.pacienteRepositoryMock.Setup(r => r.DeletarPaciente(p)).Returns(true);
            var pacienteService = new PacienteService(this.pacienteRepositoryMock.Object);

            // act
            var test = pacienteService.DeletarPaciente(id.ToString());

            // assert
            Assert.True(test);
        }

        [Fact]
        public void DeletarPaciente_PeloIdPacienteNaoExiste_RetornarFalse()
        {
            // arrange
            Guid id = Guid.NewGuid();
            Paciente p = null;
            this.pacienteRepositoryMock.Setup(r => r.GetPaciente(id.ToString())).Returns(p);
            this.pacienteRepositoryMock.Setup(r => r.DeletarPaciente(p)).Returns(true);
            var pacienteService = new PacienteService(this.pacienteRepositoryMock.Object);

            // act
            var test = pacienteService.DeletarPaciente(id.ToString());

            // assert
            Assert.False(test);
        }

        [Fact]
        public void GetPaciente_PeloId_RetornarUsuario()
        {
            // arrange
            Guid id = Guid.NewGuid();
            Paciente p = new Paciente(id, "Bruno", DateTime.Parse("1999-03-13"));
            this.pacienteRepositoryMock.Setup(r => r.GetPaciente(id.ToString())).Returns(p);
            var pacienteService = new PacienteService(this.pacienteRepositoryMock.Object);

            // act
            var paciente = pacienteService.GetPaciente(id.ToString());

            // assert
            Assert.NotNull(paciente);
            Assert.True(paciente.Nome == p.Nome);
        }

        [Fact]
        public void GetPaciente_PeloId_RetornarNull()
        {
            // arrange
            Guid id = Guid.NewGuid();
            Paciente p = null;
            this.pacienteRepositoryMock.Setup(r => r.GetPaciente(id.ToString())).Returns(p);
            var pacienteService = new PacienteService(this.pacienteRepositoryMock.Object);

            // act
            var paciente = pacienteService.GetPaciente(id.ToString());

            // assert
            Assert.Null(paciente);
        }

        [Fact]
        public void ObterPacientes_PeloNome_RetornarUsuarios()
        {
            // arrange
            string nome = "Bruno";
            Paciente p1 = new Paciente(Guid.NewGuid(), "Bruno", DateTime.Parse("1999-03-13"));
            Paciente p2 = new Paciente(Guid.NewGuid(), "Bruno", DateTime.Parse("1999-03-13"));
            var listPacientes = new List<Paciente> { p1, p2 };
            this.pacienteRepositoryMock.Setup(r => r.ObterPacientes(nome)).Returns(listPacientes);
            var pacienteService = new PacienteService(this.pacienteRepositoryMock.Object);

            // act
            var pacientes = pacienteService.ObterPacientes(nome);

            // assert
            Assert.Equal(listPacientes.Count, pacientes.Count());
            Assert.Equal(listPacientes[0].Nome, pacientes.ElementAt(0).Nome);
            Assert.Equal(listPacientes[1].Nome, pacientes.ElementAt(1).Nome);
        }

        [Fact]
        public void ObterPacientes_NenhumPaciente_RetornarListaVazia()
        {
            // arrange
            string nome = "Bruno";
            var listPacientes = new List<Paciente>();
            this.pacienteRepositoryMock.Setup(r => r.ObterPacientes(nome)).Returns(listPacientes);
            var pacienteService = new PacienteService(this.pacienteRepositoryMock.Object);

            // act
            var pacientes = pacienteService.ObterPacientes(nome);

            // assert
            Assert.Equal(listPacientes.Count, pacientes.Count());
            Assert.True(pacientes.Count() == 0);
        }
    }
}
