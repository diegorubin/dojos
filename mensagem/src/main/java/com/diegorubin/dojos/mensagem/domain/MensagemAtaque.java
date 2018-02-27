package com.diegorubin.dojos.mensagem.domain;

public class MensagemAtaque extends Mensagem {

    Posicao posicao1;
    Posicao posicao2;
    Posicao posicao3;

    public Posicao getPosicao1() {
        return posicao1;
    }

    public void setPosicao1(Posicao posicao1) {
        this.posicao1 = posicao1;
    }

    public Posicao getPosicao2() {
        return posicao2;
    }

    public void setPosicao2(Posicao posicao2) {
        this.posicao2 = posicao2;
    }

    public Posicao getPosicao3() {
        return posicao3;
    }

    public void setPosicao3(Posicao posicao3) {
        this.posicao3 = posicao3;
    }
}
