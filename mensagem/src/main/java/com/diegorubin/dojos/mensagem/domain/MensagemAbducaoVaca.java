package com.diegorubin.dojos.mensagem.domain;

public class MensagemAbducaoVaca extends Mensagem {

    Posicao posicao;
    Integer avaliacao;

    public Posicao getPosicao() {
        return posicao;
    }

    public void setPosicao(Posicao posicao) {
        this.posicao = posicao;
    }

    public Integer getAvaliacao() {
        return avaliacao;
    }

    public void setAvaliacao(Integer avaliacao) {
        this.avaliacao = avaliacao;
    }
}