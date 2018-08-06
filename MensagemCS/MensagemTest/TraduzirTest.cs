using Xunit;
using MensagemCS;
using MensagemCS.Gateways;
using MensagemCS.Domains;
using Moq;

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

        }
        

        #endregion

    }
}