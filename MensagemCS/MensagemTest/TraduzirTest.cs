using System;
using Xunit;
using MensagemCS;
using MensagemCS.Gateways;
using MensagemCS.Domains;
using Moq;
using Newtonsoft.Json.Bson;

namespace MensagemTest
{
    public class TraduzirTest
    {
        #region Setup

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
        
        #endregion
        
        #region Traduzir
        
        [Fact]
        public void deveriaInterceptarMensagemDeMudancaDePosicao()
        {
            var mensagem = new Mensagem();
            
            _nave.Setup(n => n.Interceptar()).Returns("βφ12345ι67890");
            
            _submarino.Setup(s => s.Enviar(It.IsAny<Mensagem>()))
                .Callback<Mensagem>(m => mensagem = m);
            
            _traduzir.Executar();


            Assert.IsType<MensagemMudancaPosicao>(mensagem);
            Assert.Equal(TipoMensagem.MUDANCA_POSICAO, mensagem.Tipo);
        }

        [Fact]
        public void ValidarSePosicaoEstaCorreta()
        {
            var mensagem = new Mensagem();
            var pt1 = 12345;
            var pt2 = 67890;
            
            
            _nave.Setup(n => n.Interceptar()).Returns("βφ12345ι67890");
            
            _submarino.Setup(s => s.Enviar(It.IsAny<Mensagem>()))
                .Callback<Mensagem>(m => mensagem = m);
            
            _traduzir.Executar();

            var mudancaPosicao = (MensagemMudancaPosicao)mensagem;

            Assert.IsType<MensagemMudancaPosicao>(mensagem);
            Assert.Equal(pt1, mudancaPosicao.Posicao.Ponto1);
            Assert.Equal(pt2, mudancaPosicao.Posicao.Ponto2);
        }

        [Fact]
        public void ValidarTipoMensagemAbducao()
        {
            var mensagem = new Mensagem();
            
            _nave.Setup(n => n.Interceptar()).Returns("γφ12345ι67890ζ10");
            
            _submarino.Setup(s => s.Enviar(It.IsAny<Mensagem>()))
                .Callback<Mensagem>(m => mensagem = m);
            
            _traduzir.Executar();
            
            Assert.Equal(TipoMensagem.ABDUCAO_VACA, mensagem.Tipo);
        }
        
        [Fact]
        public void QualidadeDaVaca_ShouldBe_InterceptadaCorretamente()
        {
            var mensagem = new Mensagem();

            int qualidadeVaca = 10;
            
            _nave.Setup(n => n.Interceptar()).Returns("γφ12345ι67890ζ10");
            
            _submarino.Setup(s => s.Enviar(It.IsAny<Mensagem>()))
                .Callback<Mensagem>(m => mensagem = (MensagemAtque) m);
            
            _traduzir.Executar();

            MensagemAtque msg = (MensagemAtque) mensagem;
            
            Assert.Equal(qualidadeVaca, msg.QualidadeVaca);
        }

        [Fact]
        public void ValidarTipoMensagemAtaque()
        {
            var mensagem = new Mensagem();
            
            _nave.Setup(n => n.Interceptar()).Returns("αφ1ι2φ3ι4φ5ι6");
            
            _submarino.Setup(s => s.Enviar(It.IsAny<Mensagem>()))
                .Callback<Mensagem>(m => mensagem = (MensagemAtque) m);
            
            _traduzir.Executar();
            
            Assert.Equal(TipoMensagem.ATAQUE, mensagem.Tipo);
        }
        
        [Fact]
        public void ValidarPosicoesDeAtaque()
        {
            var mensagem = new Mensagem();
            
            _nave.Setup(n => n.Interceptar()).Returns("αφ1ι2φ3ι4φ5ι6");
            
            _submarino.Setup(s => s.Enviar(It.IsAny<Mensagem>()))
                .Callback<Mensagem>(m => mensagem = (MensagemAtque) m);
            
            _traduzir.Executar();

            var mensagemAtaque = (MensagemAtque) mensagem;

            Assert.Equal(mensagemAtaque.Posicao1.Ponto1, 1);
            Assert.Equal(mensagemAtaque.Posicao1.Ponto2, 2);
            Assert.Equal(mensagemAtaque.Posicao2.Ponto1, 3);
            Assert.Equal(mensagemAtaque.Posicao2.Ponto2, 4);
            Assert.Equal(mensagemAtaque.Posicao3.Ponto1, 5);
            Assert.Equal(mensagemAtaque.Posicao3.Ponto2, 6);
        }

        [Fact]
        public void ValidarMensagemVazia()
        {
            var mensagem = new Mensagem();

            _nave.Setup(n => n.Interceptar()).Returns("");

            Assert.Throws<ArgumentException>(() => _traduzir.Executar());
        }

        [Fact]
        public void ValidarMensagemNaoIdentificada()
        {
            var mensagem = new Mensagem();
            
            _nave.Setup(n => n.Interceptar()).Returns("$marmita10");
            
            _submarino.Setup(s => s.Enviar(It.IsAny<Mensagem>()))
                .Callback<Mensagem>(m => mensagem = (MensagemAtque) m);
            
            _traduzir.Executar();
            
            var assert = Assert.Throws<ArgumentException>(() => _traduzir.Executar());
            
            Assert.Equal(assert.Message, "Mensagem não identificada!");
        }
        
        #endregion

    }
}