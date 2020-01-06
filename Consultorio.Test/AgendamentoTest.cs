using Consultorio.Application.ViewModel;
using Consultorio.Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Consultorio.Domain.Entity;
using Consultorio.Application.Service;

namespace Consultorio.Test
{
    public class AgendamentoTest
    {
        //[metodo]_[condicao]_[ResultadoEsperado]

        private readonly Mock<IAgendamentoRepository> agendamentoRepositoryMock;
        private readonly Mock<IPacienteRepository> pacienteRepositoryMock;
        public AgendamentoTest()
        {
            this.agendamentoRepositoryMock = new Mock<IAgendamentoRepository>();
            this.pacienteRepositoryMock = new Mock<IPacienteRepository>();
        }

        [Fact]
        public void AtualizarAgendamento_TerAgendamento_RetornarTrue()
        {
            // arrange
            var a = new AgendamentoViewModel(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T10:00"), DateTime.Parse("2000-01-01T11:00"), "obs");
            this.agendamentoRepositoryMock.Setup(r => r.ObterAgendamentos(It.IsAny<Agendamento>(), true)).Returns(new List<Agendamento>());
            this.agendamentoRepositoryMock.Setup(r => r.AtualizarAgendamento(It.IsAny<Agendamento>())).Returns(true);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var test = agendamentoService.AtualizarAgendamento(a);

            // assert
            Assert.True(test);
        }

        [Fact]
        public void AtualizarAgendamento_AgendamentoHorarioFinalMenorQueHorarioInicial_RetornarFalse()
        {
            // arrange
            var a = new AgendamentoViewModel(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T11:00"), DateTime.Parse("2000-01-01T10:00"), "obs");
            this.agendamentoRepositoryMock.Setup(r => r.ObterAgendamentos(It.IsAny<Agendamento>(), true)).Returns(new List<Agendamento>());
            this.agendamentoRepositoryMock.Setup(r => r.AtualizarAgendamento(It.IsAny<Agendamento>())).Returns(true);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var test = agendamentoService.AtualizarAgendamento(a);

            // assert
            Assert.False(test);
        }

        [Fact]
        public void AtualizarAgendamento_AgendamentoComConflito_RetornarFalse()
        {
            // arrange
            var a1 = new Agendamento(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T10:00"), DateTime.Parse("2000-01-01T11:00"), "obs");
            var a2 = new Agendamento(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T11:00"), DateTime.Parse("2000-01-01T12:00"), "obs");

            var a = new AgendamentoViewModel(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T09:30"), DateTime.Parse("2000-01-01T10:30"), "obs");
            this.agendamentoRepositoryMock.Setup(r => r.ObterAgendamentos(It.IsAny<Agendamento>(), true)).Returns(new List<Agendamento> { a1, a2});
            this.agendamentoRepositoryMock.Setup(r => r.AtualizarAgendamento(It.IsAny<Agendamento>())).Returns(true);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var test = agendamentoService.AtualizarAgendamento(a);

            // assert
            Assert.False(test);
        }
        [Fact]
        public void CadastrarAgendamento_TerAgendamento_RetornarTrue()
        {
            // arrange
            var a = new AgendamentoViewModel(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T10:00"), DateTime.Parse("2000-01-01T11:00"), "obs");
            this.agendamentoRepositoryMock.Setup(r => r.ObterAgendamentos(It.IsAny<Agendamento>(), false)).Returns(new List<Agendamento>());
            this.agendamentoRepositoryMock.Setup(r => r.CadastrarAgendamento(It.IsAny<Agendamento>())).Returns(true);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var test = agendamentoService.CadastrarAgendamento(a);

            // assert
            Assert.True(test);
        }

        [Fact]
        public void CadastrarAgendamento_AgendamentoHorarioFinalMenorQueHorarioInicial_RetornarFalse()
        {
            // arrange
            var a = new AgendamentoViewModel(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T11:00"), DateTime.Parse("2000-01-01T10:00"), "obs");
            this.agendamentoRepositoryMock.Setup(r => r.ObterAgendamentos(It.IsAny<Agendamento>(), false)).Returns(new List<Agendamento>());
            this.agendamentoRepositoryMock.Setup(r => r.CadastrarAgendamento(It.IsAny<Agendamento>())).Returns(true);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var test = agendamentoService.CadastrarAgendamento(a);

            // assert
            Assert.False(test);
        }

        [Fact]
        public void CadastrarAgendamento_AgendamentoComConflito_RetornarFalse()
        {
            // arrange
            var a1 = new Agendamento(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T10:00"), DateTime.Parse("2000-01-01T11:00"), "obs");
            var a2 = new Agendamento(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T11:00"), DateTime.Parse("2000-01-01T12:00"), "obs");

            var a = new AgendamentoViewModel(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T09:30"), DateTime.Parse("2000-01-01T10:30"), "obs");
            this.agendamentoRepositoryMock.Setup(r => r.ObterAgendamentos(It.IsAny<Agendamento>(), false)).Returns(new List<Agendamento> { a1, a2 });
            this.agendamentoRepositoryMock.Setup(r => r.CadastrarAgendamento(It.IsAny<Agendamento>())).Returns(true);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var test = agendamentoService.CadastrarAgendamento(a);

            // assert
            Assert.False(test);
        }

        [Fact]
        public void DeletarAgendamento_PeloId_RetornarTrue()
        {
            // arrange
            Guid id = Guid.NewGuid();
            var a = new Agendamento(id, Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T10:00"), DateTime.Parse("2000-01-01T11:00"), "obs");
            this.agendamentoRepositoryMock.Setup(r => r.GetAgendamento(id.ToString())).Returns(a);
            this.agendamentoRepositoryMock.Setup(r => r.DeletarAgendamento(a)).Returns(true);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var test = agendamentoService.DeletarAgendamento(id.ToString());

            // assert
            Assert.True(test);
        }

        [Fact]
        public void DeletarPaciente_PeloIdPacienteNaoExiste_RetornarFalse()
        {
            // arrange
            Guid id = Guid.NewGuid();
            Agendamento a = null;
            this.agendamentoRepositoryMock.Setup(r => r.GetAgendamento(id.ToString())).Returns(a);
            this.agendamentoRepositoryMock.Setup(r => r.DeletarAgendamento(a)).Returns(true);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var test = agendamentoService.DeletarAgendamento(id.ToString());

            // assert
            Assert.False(test);
        }

        [Fact]
        public void GetAgendamento_PeloId_RetornarAgendamento()
        {
            // arrange
            Guid id = Guid.NewGuid();
            var a = new Agendamento(id, Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T10:00"), DateTime.Parse("2000-01-01T11:00"), "obs");
            this.agendamentoRepositoryMock.Setup(r => r.GetAgendamento(id.ToString())).Returns(a);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var agendamento = agendamentoService.GetAgendamento(id.ToString());

            // assert
            Assert.NotNull(agendamento);
            Assert.True(agendamento.Id == a.Id && agendamento.IdPaciente == a.IdPaciente);
        }

        [Fact]
        public void GetAgendamento_PeloId_RetornarNull()
        {
            // arrange
            Guid id = Guid.NewGuid();
            Agendamento a = null;
            this.agendamentoRepositoryMock.Setup(r => r.GetAgendamento(id.ToString())).Returns(a);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var agendamento = agendamentoService.GetAgendamento(id.ToString());

            // assert
            Assert.Null(agendamento);
        }

        [Fact]
        public void GetAgendamentoPaciente_PeloId_RetornarAgendamentoComPaciente()
        {
            // arrange
            Guid id = Guid.NewGuid();
            Guid idPaciente = Guid.NewGuid();
            var p = new Paciente(idPaciente, "Bruno", DateTime.Parse("1999-03-13"));
            var a = new Agendamento(id, Guid.NewGuid(), idPaciente, DateTime.Parse("2000-01-01T10:00"), DateTime.Parse("2000-01-01T11:00"), "obs");
            this.agendamentoRepositoryMock.Setup(r => r.GetAgendamento(id.ToString())).Returns(a);
            this.pacienteRepositoryMock.Setup(r => r.GetPaciente(a.IdPaciente.ToString())).Returns(p);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object, this.pacienteRepositoryMock.Object);

            // act
            var agendamento = agendamentoService.GetAgendamentoPaciente(id.ToString());

            // assert
            Assert.NotNull(agendamento);
            Assert.True(agendamento.Id == a.Id && agendamento.Paciente.Id == a.IdPaciente);
        }

        [Fact]
        public void GetAgendamentoPaciente_PeloIdSemAgendamento_RetornarNull()
        {
            // arrange
            Guid id = Guid.NewGuid();
            Guid idPaciente = Guid.NewGuid();
            var p = new Paciente(idPaciente, "Bruno", DateTime.Parse("1999-03-13"));
            Agendamento a = null;
            this.agendamentoRepositoryMock.Setup(r => r.GetAgendamento(id.ToString())).Returns(a);
            this.pacienteRepositoryMock.Setup(r => r.GetPaciente(idPaciente.ToString())).Returns(p);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object, this.pacienteRepositoryMock.Object);

            // act
            var agendamento = agendamentoService.GetAgendamentoPaciente(id.ToString());

            // assert
            Assert.Null(agendamento);
        }

        [Fact]
        public void GetAgendamentoPaciente_PeloIdSemPaciente_RetornarNull()
        {
            // arrange
            Guid id = Guid.NewGuid();
            Guid idPaciente = Guid.NewGuid();
            Paciente p = null;
            var a = new Agendamento(id, Guid.NewGuid(), idPaciente, DateTime.Parse("2000-01-01T10:00"), DateTime.Parse("2000-01-01T11:00"), "obs");
            this.agendamentoRepositoryMock.Setup(r => r.GetAgendamento(id.ToString())).Returns(a);
            this.pacienteRepositoryMock.Setup(r => r.GetPaciente(a.IdPaciente.ToString())).Returns(p);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object, this.pacienteRepositoryMock.Object);

            // act
            var agendamento = agendamentoService.GetAgendamentoPaciente(id.ToString());

            // assert
            Assert.Null(agendamento);
        }

        [Fact]
        public void GetAgendamentoPaciente_PeloIdSemAgendamentoPaciente_RetornarNull()
        {
            // arrange
            Guid id = Guid.NewGuid();
            Guid idPaciente = Guid.NewGuid();
            Paciente p = null;
            Agendamento a = null;
            this.agendamentoRepositoryMock.Setup(r => r.GetAgendamento(id.ToString())).Returns(a);
            this.pacienteRepositoryMock.Setup(r => r.GetPaciente(idPaciente.ToString())).Returns(p);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object, this.pacienteRepositoryMock.Object);

            // act
            var agendamento = agendamentoService.GetAgendamentoPaciente(id.ToString());

            // assert
            Assert.Null(agendamento);
        }

        [Fact]
        public void ObterAgendamentos_PelaData_RetornarAgendamentos()
        {
            // arrange
            DateTime data = DateTime.Parse("2000-01-01");
            var a1 = new Agendamento(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T10:00"), DateTime.Parse("2000-01-01T11:00"), "obs");
            var a2 = new Agendamento(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Parse("2000-01-01T11:00"), DateTime.Parse("2000-01-01T12:00"), "obs");
            var listAgendamentos = new List<Agendamento> { a1, a2 };
            this.agendamentoRepositoryMock.Setup(r => r.ObterAgendamentos(data, true)).Returns(listAgendamentos);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var agendamentos = agendamentoService.ObterAgendamentos(data, true);

            // assert
            Assert.Equal(listAgendamentos.Count, agendamentos.Count());
            Assert.Equal(listAgendamentos[0].Id, agendamentos.ElementAt(0).Id);
            Assert.Equal(listAgendamentos[1].Id, agendamentos.ElementAt(1).Id);
        }

        [Fact]
        public void ObterAgendamentos_PelaDataVazio_RetornarListaVazia()
        {
            // arrange
            DateTime data = DateTime.Parse("2000-01-01");
            var listAgendamentos = new List<Agendamento>();
            this.agendamentoRepositoryMock.Setup(r => r.ObterAgendamentos(data, true)).Returns(listAgendamentos);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var agendamentos = agendamentoService.ObterAgendamentos(data, true);

            // assert
            Assert.Equal(listAgendamentos.Count, agendamentos.Count());
            Assert.True(agendamentos.Count() == 0);
        }

        [Fact]
        public void ObterAgendamentosPaciente_PelaData_RetornarAgendamentosComPaciente()
        {
            // arrange
            DateTime data = DateTime.Parse("2000-01-01");
            Guid idPaciente1 = Guid.NewGuid();
            Guid idPaciente2 = Guid.NewGuid();
            var p1 = new Paciente(idPaciente1, "Bruno", DateTime.Parse("1999-03-13"));
            var p2 = new Paciente(idPaciente2, "Bruno 2", DateTime.Parse("1999-03-13"));
            var a1 = new Agendamento(Guid.NewGuid(), Guid.NewGuid(), idPaciente1, DateTime.Parse("2000-01-01T10:00"), DateTime.Parse("2000-01-01T11:00"), "obs");
            var a2 = new Agendamento(Guid.NewGuid(), Guid.NewGuid(), idPaciente2, DateTime.Parse("2000-01-01T11:00"), DateTime.Parse("2000-01-01T12:00"), "obs");
            var listAgendamentos = new List<Agendamento> { a1, a2 };
            this.agendamentoRepositoryMock.Setup(r => r.ObterAgendamentos(data, true)).Returns(listAgendamentos);
            this.pacienteRepositoryMock.Setup(r => r.GetPaciente(a1.IdPaciente.ToString())).Returns(p1);
            this.pacienteRepositoryMock.Setup(r => r.GetPaciente(a2.IdPaciente.ToString())).Returns(p2);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object, this.pacienteRepositoryMock.Object);

            // act
            var agendamentos = agendamentoService.ObterAgendamentosPaciente(data, true);

            // assert
            Assert.Equal(listAgendamentos.Count, agendamentos.Count());
            Assert.Equal(listAgendamentos[0].Id, agendamentos.ElementAt(0).Id);
            Assert.Equal(listAgendamentos[1].Id, agendamentos.ElementAt(1).Id);
            Assert.Equal(p1.Id, agendamentos.ElementAt(0).Paciente.Id);
            Assert.Equal(p2.Id, agendamentos.ElementAt(1).Paciente.Id);
        }

        [Fact]
        public void ObterAgendamentosPaciente_PelaDataVazio_RetornarListaVazia()
        {
            // arrange
            DateTime data = DateTime.Parse("2000-01-01");
            Guid idPaciente1 = Guid.NewGuid();
            Guid idPaciente2 = Guid.NewGuid();
            var p1 = new Paciente(idPaciente1, "Bruno", DateTime.Parse("1999-03-13"));
            var p2 = new Paciente(idPaciente2, "Bruno 2", DateTime.Parse("1999-03-13"));
            var listAgendamentos = new List<Agendamento>();
            this.agendamentoRepositoryMock.Setup(r => r.ObterAgendamentos(data, true)).Returns(listAgendamentos);
            this.pacienteRepositoryMock.Setup(r => r.GetPaciente(idPaciente1.ToString())).Returns(p1);
            this.pacienteRepositoryMock.Setup(r => r.GetPaciente(idPaciente2.ToString())).Returns(p2);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object, this.pacienteRepositoryMock.Object);

            // act
            var agendamentos = agendamentoService.ObterAgendamentosPaciente(data, true);

            // assert
            Assert.Equal(listAgendamentos.Count, agendamentos.Count());
            Assert.True(agendamentos.Count() == 0);
        }

        [Fact]
        public void ObterAgendamentosPaciente_PeloNomePaciente_RetornarAgendamentosComPaciente()
        {
            // arrange
            string nome = "Bruno";
            Guid idPaciente1 = Guid.NewGuid();
            Guid idPaciente2 = Guid.NewGuid();
            var p1 = new Paciente(idPaciente1, "Bruno", DateTime.Parse("1999-03-13"));
            var p2 = new Paciente(idPaciente2, "Bruno 2", DateTime.Parse("1999-03-13"));
            var a1 = new Agendamento(Guid.NewGuid(), Guid.NewGuid(), idPaciente1, DateTime.Parse("2000-01-01T10:00"), DateTime.Parse("2000-01-01T11:00"), "obs");
            var a2 = new Agendamento(Guid.NewGuid(), Guid.NewGuid(), idPaciente2, DateTime.Parse("2000-01-01T11:00"), DateTime.Parse("2000-01-01T12:00"), "obs");
            a1.Paciente = p1;
            a2.Paciente = p2;
            var listAgendamentos = new List<Agendamento> { a1, a2 };
            this.agendamentoRepositoryMock.Setup(r => r.ObterAgendamentos(nome)).Returns(listAgendamentos);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var agendamentos = agendamentoService.ObterAgendamentosPaciente(nome);

            // assert
            Assert.Equal(listAgendamentos.Count, agendamentos.Count());
            Assert.Equal(listAgendamentos[0].Id, agendamentos.ElementAt(0).Id);
            Assert.Equal(listAgendamentos[1].Id, agendamentos.ElementAt(1).Id);
            Assert.Equal(p1.Id, agendamentos.ElementAt(0).Paciente.Id);
            Assert.Equal(p2.Id, agendamentos.ElementAt(1).Paciente.Id);
        }

        [Fact]
        public void ObterAgendamentosPaciente_PeloNomePacienteSemAgendamentos_RetornarListaVazia()
        {
            // arrange
            string nome = "Bruno";
            var listAgendamentos = new List<Agendamento> ();
            this.agendamentoRepositoryMock.Setup(r => r.ObterAgendamentos(nome)).Returns(listAgendamentos);
            var agendamentoService = new AgendamentoService(this.agendamentoRepositoryMock.Object);

            // act
            var agendamentos = agendamentoService.ObterAgendamentosPaciente(nome);

            // assert
            Assert.Equal(listAgendamentos.Count, agendamentos.Count());
            Assert.True(agendamentos.Count() == 0);
        }
    }
}
