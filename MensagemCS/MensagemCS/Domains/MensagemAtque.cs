namespace MensagemCS.Domains
{
    public class MensagemAtque : Mensagem
    {
        public Posicao Posicao1 { set; get; }
        public Posicao Posicao2 { set; get; }
        public Posicao Posicao3 { set; get; }
        public int QualidadeVaca { get; set; }
    }
}