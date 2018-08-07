using System;
using System.Text;
using MensagemCS.Domains;
using MensagemCS.Gateways;

namespace MensagemCS
{
    public class Traduzir
    {
        private INaveMae _naveMae;
        private ISubmarinoRusso _submarinoRusso;

        public Traduzir(INaveMae naveMae, ISubmarinoRusso submarinoRusso)
        {
            _naveMae = naveMae;
            _submarinoRusso = submarinoRusso;
        }

        public void Executar()
        {
            var rawMessage = new StringBuilder(_naveMae.Interceptar());
            var mensagem = Executar(rawMessage);
            _submarinoRusso.Enviar(mensagem);
        }

        private Mensagem Executar(StringBuilder rawMessage)
        {
            var tipo = GetChar(rawMessage);
            if (tipo == 'β')
            {
                return GetNextMensagemMudancaPosicao(rawMessage);
            }

            if (tipo == 'α')
            {
                return GetNextMensagemAtaque(rawMessage);
            }

            if (tipo == 'γ')
            {
                return GetNextMensagemAbducao(rawMessage);
            }

            throw new Exception("mensagem invalida");
        }

        private Mensagem GetNextMensagemAtaque(StringBuilder message)
        {
            MensagemAtaque mensagemAtaque = new MensagemAtaque();
            mensagemAtaque.Tipo = TipoMensagem.ATAQUE;
            mensagemAtaque.Posicao1 = GetNextPosition(message);
            mensagemAtaque.Posicao2 = GetNextPosition(message);
            mensagemAtaque.Posicao3 = GetNextPosition(message);
            return mensagemAtaque;
        }

        private Mensagem GetNextMensagemAbducao(StringBuilder message)
        {
            var mensagemMudancaPosicao = new MensagemAbducaoVaca();
            mensagemMudancaPosicao.Tipo = TipoMensagem.ABDUCAO_VACA;
            mensagemMudancaPosicao.Posicao = GetNextPosition(message);
            mensagemMudancaPosicao.Avaliacao = GetAvaliacao(message);
            return mensagemMudancaPosicao;
        }

        private Mensagem GetNextMensagemMudancaPosicao(StringBuilder message)
        {
            var mensagemMudancaPosicao = new MensagemMudancaPosicao();
            mensagemMudancaPosicao.Tipo = TipoMensagem.MUDANCA_POSICAO;
            mensagemMudancaPosicao.Posicao = GetNextPosition(message);
            return mensagemMudancaPosicao;
        }

        private int GetAvaliacao(StringBuilder message)
        {
            // caracter de avaliacao
            GetChar(message);
            return GetNextNumber(message);
        }

        private char GetChar(StringBuilder message)
        {
            var firstChar = message[0];
            message.Remove(0, 1);
            return firstChar;
        }

        private void UngetChar(StringBuilder message, char returnedChar)
        {
            message.Insert(0, returnedChar);
        }

        private Posicao GetNextPosition(StringBuilder message)
        {
            Posicao posicao = new Posicao();
            // Caracter que informa um ponto
            GetChar(message);
            posicao.Ponto1 = GetNextNumber(message);
            // Caracter que informa separador de ponto
            GetChar(message);
            posicao.Ponto2 = GetNextNumber(message);
            return posicao;
        }

        private int GetNextNumber(StringBuilder message)
        {
            var number = "";

            try
            {
                char c;
                while (char.IsDigit(c = GetChar(message)))
                {
                    number = string.Concat(number, c);
                }

                UngetChar(message, c);
            }
            catch (IndexOutOfRangeException)
            {
            }

            return int.Parse(number);
        }
    }
}