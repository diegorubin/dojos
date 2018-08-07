using System;
using Xunit;
using MensagemCS;
using MensagemCS.Gateways;
using MensagemCS.Domains;
using Moq;

namespace MensagemTest
{
    public class TraduzirTest
    {
        private Traduzir _traduzir;
        private Mock<INaveMae> _nave;
        private Mock<ISubmarinoRusso> _submarino;
        private Mensagem _mensagem;

        public TraduzirTest()
        {
            _nave = new Mock<INaveMae>();
            _submarino = new Mock<ISubmarinoRusso>();
            _traduzir = new Traduzir(_nave.Object, _submarino.Object);
        }

        [Fact]
        public void DeveriaInterceptarMensagemDeMudancaDePosicao()
        {
            _nave.Setup(x => x.Interceptar()).Returns("βφ1234ι5678");
            _submarino.Setup(x => x.Enviar(It.IsAny<Mensagem>())).Callback<Mensagem>(r => _mensagem = r);
            _traduzir.Executar();

            var mudanca = _mensagem as MensagemMudancaPosicao;
            Assert.Equal(TipoMensagem.MUDANCA_POSICAO, mudanca.Tipo);
            Assert.Equal(1234, mudanca.Posicao.Ponto1);
            Assert.Equal(5678, mudanca.Posicao.Ponto2);
        }

        [Fact]
        public void DeveriaInterceptarMensagemDeAbducao()
        {
            _nave.Setup(x => x.Interceptar()).Returns("γφ1234ι5678ζ10");
            _submarino.Setup(x => x.Enviar(It.IsAny<Mensagem>())).Callback<Mensagem>(r => _mensagem = r);
            _traduzir.Executar();

            var abducao = _mensagem as MensagemAbducaoVaca;
            Assert.Equal(TipoMensagem.ABDUCAO_VACA, _mensagem.Tipo);
            Assert.Equal(1234, abducao.Posicao.Ponto1);
            Assert.Equal(5678, abducao.Posicao.Ponto2);
            Assert.Equal(10, abducao.Avaliacao);
        }

        [Fact]
        public void DeveriaInterceptarAtaque()
        {
            _nave.Setup(x => x.Interceptar()).Returns("αφ1ι2φ3ι4φ5ι6");
            _submarino.Setup(x => x.Enviar(It.IsAny<Mensagem>())).Callback<Mensagem>(r => _mensagem = r);
            _traduzir.Executar();

            var ataque = _mensagem as MensagemAtaque;
            Assert.Equal(TipoMensagem.ATAQUE, ataque.Tipo);
            Assert.Equal(1, ataque.Posicao1.Ponto1);
            Assert.Equal(2, ataque.Posicao1.Ponto2);
            Assert.Equal(3, ataque.Posicao2.Ponto1);
            Assert.Equal(4, ataque.Posicao2.Ponto2);
            Assert.Equal(5, ataque.Posicao3.Ponto1);
            Assert.Equal(6, ataque.Posicao3.Ponto2);
        }

        [Fact]
        public void MensagemInvalida()
        {
            _nave.Setup(x => x.Interceptar()).Returns("1234ι5678");
            Assert.Throws<Exception>(() => _traduzir.Executar());
        }

    }
}