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
    public class UsuarioTest
    {
        //[metodo]_[condicao]_[ResultadoEsperado]

        private readonly Mock<IUsuarioRepository> usuarioRepositoryMock;
        public UsuarioTest()
        {
            this.usuarioRepositoryMock = new Mock<IUsuarioRepository>();
        }

        [Fact]
        public void CadastrarUsuario_TerUsuario_RetornarTrue()
        {
            // arrange
            var usuarioViewModel = new UsuarioViewModel("Bruno", "bruno", "bruno123");
            this.usuarioRepositoryMock.Setup(u => u.CadastrarUsuario(It.IsAny<Usuario>())).Returns(true);
            var usuarioService = new UsuarioService(this.usuarioRepositoryMock.Object);

            // act
            var test = usuarioService.CadastrarUsuario(usuarioViewModel);

            // assert
            Assert.True(test);
        }

        [Fact]
        public void CadastrarUsuario_ComLoginExistente_RetornarFalse()
        {
            // arrange
            var usuarioViewModel = new UsuarioViewModel("Bruno", "bruno", "bruno123");
            var usuario = new Usuario("Bruno", "bruno", "bruno123");
            this.usuarioRepositoryMock.Setup(u => u.GetUsuarioLogin("bruno")).Returns(usuario);
            this.usuarioRepositoryMock.Setup(u => u.CadastrarUsuario(It.IsAny<Usuario>())).Returns(true);
            var usuarioService = new UsuarioService(this.usuarioRepositoryMock.Object);

            // act
            var test = usuarioService.CadastrarUsuario(usuarioViewModel);

            // assert
            Assert.False(test);
        }

        [Fact]
        public void GetUsuario_PeloId_RetornarUsuario()
        {
            // arrange
            Guid id = Guid.NewGuid();
            var usuarioRetorno = new Usuario(id, "Bruno", "bruno", "bruno123");
            this.usuarioRepositoryMock.Setup(u => u.GetUsuario(id.ToString())).Returns(usuarioRetorno);
            var usuarioService = new UsuarioService(this.usuarioRepositoryMock.Object);

            // act
            var usuario = usuarioService.GetUsuario(id.ToString());

            // assert
            Assert.NotNull(usuario);
            Assert.True(usuario.Nome == usuarioRetorno.Nome);
        }

        [Fact]
        public void GetUsuario_PeloId_RetornarNull()
        {
            // arrange
            Guid id = Guid.NewGuid();
            Usuario a = null;
            this.usuarioRepositoryMock.Setup(u => u.GetUsuario(id.ToString())).Returns(a);
            var usuarioService = new UsuarioService(this.usuarioRepositoryMock.Object);

            // act
            var usuario = usuarioService.GetUsuario(id.ToString());

            // assert
            Assert.Null(usuario);
        }


        [Fact]
        public void GetUsuario_PeloLoginSenha_RetornarUsuario()
        {
            // arrange
            Usuario a = new Usuario("Bruno","bruno","123456");
            this.usuarioRepositoryMock.Setup(u => u.GetUsuario(a.Login, a.Senha)).Returns(a);
            var usuarioService = new UsuarioService(this.usuarioRepositoryMock.Object);

            // act
            var usuario = usuarioService.GetUsuario(a.Login, a.Senha);

            // assert
            Assert.True(usuario.Nome == a.Nome);
        }

        [Fact]
        public void GetUsuario_PeloLoginSenha_RetornarNull()
        {
            // arrange
            Usuario a = new Usuario("Bruno", "bruno", "123456");
            Usuario n = null;
            this.usuarioRepositoryMock.Setup(u => u.GetUsuario(a.Login, a.Senha)).Returns(n);
            var usuarioService = new UsuarioService(this.usuarioRepositoryMock.Object);

            // act
            var usuario = usuarioService.GetUsuario(a.Login, a.Senha);

            // assert
            Assert.Null(usuario);
        }

        [Fact]
        public void ObterUsuarios_PeloNome_RetornarUsuarios()
        {
            // arrange
            string nome = "Bruno";
            Usuario a = new Usuario("Bruno", "bruno", "123456");
            Usuario b = new Usuario("Bruno 2", "brunin", "654321");
            var listUsuarios = new List<Usuario> { a, b };
            this.usuarioRepositoryMock.Setup(u => u.ObterUsuarios(nome)).Returns(listUsuarios);
            var usuarioService = new UsuarioService(this.usuarioRepositoryMock.Object);

            // act
            var usuarios = usuarioService.ObterUsuarios(nome);

            // assert
            Assert.Equal(listUsuarios.Count, usuarios.Count());
            Assert.Equal(listUsuarios[0].Nome, usuarios.ElementAt(0).Nome);
            Assert.Equal(listUsuarios[1].Nome, usuarios.ElementAt(1).Nome);
        }

        [Fact]
        public void ObterUsuarios_NenhumUsuario_RetornarListaVazia()
        {
            // arrange
            string nome = "Bruno";
            var listUsuarios = new List<Usuario>();
            this.usuarioRepositoryMock.Setup(u => u.ObterUsuarios(nome)).Returns(listUsuarios);
            var usuarioService = new UsuarioService(this.usuarioRepositoryMock.Object);

            // act
            var usuarios = usuarioService.ObterUsuarios(nome);

            // assert
            Assert.Equal(listUsuarios.Count, usuarios.Count());
            Assert.True(usuarios.Count() == 0);
        }

        [Fact]
        public void DeletarUsuario_PeloId_RetornarTrue()
        {
            // arrange
            Guid id = Guid.NewGuid();
            Usuario a = new Usuario(id, "Bruno", "bruno", "123456");
            this.usuarioRepositoryMock.Setup(u => u.GetUsuario(id.ToString())).Returns(a);
            this.usuarioRepositoryMock.Setup(u => u.DeletarUsuario(a)).Returns(true);
            var usuarioService = new UsuarioService(this.usuarioRepositoryMock.Object);

            // act
            var test = usuarioService.DeletarUsuario(id.ToString());

            // assert
            Assert.True(test);
        }

        [Fact]
        public void DeletarUsuario_PeloIdUsuarioNaoExiste_RetornarFalse()
        {
            // arrange
            Guid id = Guid.NewGuid();
            Usuario a = null;
            this.usuarioRepositoryMock.Setup(u => u.GetUsuario(id.ToString())).Returns(a);
            this.usuarioRepositoryMock.Setup(u => u.DeletarUsuario(a)).Returns(true);
            var usuarioService = new UsuarioService(this.usuarioRepositoryMock.Object);

            // act
            var test = usuarioService.DeletarUsuario(id.ToString());

            // assert
            Assert.False(test);
        }

        [Fact]
        public void AtualizarUsuario_TerUsuario_RetornarTrue()
        {
            // arrange
            var usuarioViewModel = new UsuarioViewModel(Guid.NewGuid(), "BrunoAlterado", "bruno", "bruno123");
            this.usuarioRepositoryMock.Setup(u => u.AtualizarUsuario(It.IsAny<Usuario>())).Returns(true);
            var usuarioService = new UsuarioService(this.usuarioRepositoryMock.Object);

            // act
            var test = usuarioService.AtualizarUsuario(usuarioViewModel);

            // assert
            Assert.True(test);
        }

        [Fact]
        public void AtualizarUsuario_ComLoginExistente_RetornarFalse()
        {
            // arrange
            var usuarioViewModel = new UsuarioViewModel(Guid.NewGuid(), "BrunoAlterado", "bruno", "bruno123");
            Usuario a = new Usuario(usuarioViewModel.Id, usuarioViewModel.Nome, usuarioViewModel.Login, usuarioViewModel.Senha);
            this.usuarioRepositoryMock.Setup(u => u.AtualizarUsuario(It.IsAny<Usuario>())).Returns(false);
            var usuarioService = new UsuarioService(this.usuarioRepositoryMock.Object);

            // act
            var test = usuarioService.AtualizarUsuario(usuarioViewModel);

            // assert
            Assert.False(test);
        }
    }
}
