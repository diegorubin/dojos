using System.Collections.Specialized;
using MensagemCS.Domains;
using MensagemCS.Gateways;
using System;

namespace MensagemCS
{
    public class Traduzir
    {
        private INaveMae _naveMae;
        private ISubmarinoRusso _submarinoRusso;

        public Traduzir(INaveMae naveMae, ISubmarinoRusso submarinoRusso)
        {
            this._naveMae = naveMae;
            this._submarinoRusso = submarinoRusso;
        }

        public void Executar()
        {
            var mensagemString = _naveMae.Interceptar();

            if (string.IsNullOrWhiteSpace(mensagemString))
            {
                throw new ArgumentException("Mensagem em branco!");
            }
            
            Mensagem mensagem;

            switch (mensagemString[0])
            {
                    case 'β':
                        mensagem = MensagemMudancaPosicao(mensagemString);
                        break;
                    case 'α':
                        mensagem = MensagemAtaque(mensagemString);
                        break;
                    case 'γ':
                        mensagem = MensagemAbducaoVaca(mensagemString);
                        break;
                    default:
                        throw new ArgumentException("Mensagem não identificada!");
            }

            _submarinoRusso.Enviar(mensagem);
        }

        private static Mensagem MensagemAbducaoVaca(string mensagemString)
        {
            var messageArray = mensagemString.Split('ζ');
            var mensagemSemGama = messageArray[0].Replace("γφ", string.Empty).Split('ι');

            var ponto1 = Convert.ToInt32(mensagemSemGama[0]);
            var ponto2 = Convert.ToInt32(mensagemSemGama[1]);

            return new MensagemAtque
            {
                Posicao1 = new Posicao
                {
                    Ponto1 = ponto1,
                    Ponto2 = ponto2
                },

                Tipo = TipoMensagem.ABDUCAO_VACA,
                QualidadeVaca = Int32.Parse(messageArray[1])
            };
        }

        private static Mensagem MensagemAtaque(string mensagemString)
        {
            var posicoes = mensagemString.Replace("αφ", string.Empty).Split('φ');

            var pos1 = new Posicao
            {
                Ponto1 = int.Parse(posicoes[0].Split('ι')[0]),
                Ponto2 = int.Parse(posicoes[0].Split('ι')[1]),
            };

            var pos2 = new Posicao
            {
                Ponto1 = int.Parse(posicoes[1].Split('ι')[0]),
                Ponto2 = int.Parse(posicoes[1].Split('ι')[1]),
            };

            var pos3 = new Posicao
            {
                Ponto1 = int.Parse(posicoes[2].Split('ι')[0]),
                Ponto2 = int.Parse(posicoes[2].Split('ι')[1]),
            };

            return new MensagemAtque
            {
                Tipo = TipoMensagem.ATAQUE,
                Posicao1 = pos1,
                Posicao2 = pos2,
                Posicao3 = pos3,
            };
        }

        private static Mensagem MensagemMudancaPosicao(string mensagemString)
        {
            var mensagemSemBeta = mensagemString.Replace("βφ", string.Empty).Split('ι');

            var ponto1 = Convert.ToInt32(mensagemSemBeta[0]);
            var ponto2 = Convert.ToInt32(mensagemSemBeta[1]);

            return new MensagemMudancaPosicao
            {
                Posicao = new Posicao
                {
                    Ponto1 = ponto1,
                    Ponto2 = ponto2
                },

                Tipo = TipoMensagem.MUDANCA_POSICAO
            };
        }
    }
}