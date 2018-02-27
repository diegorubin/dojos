package com.diegorubin.dojos.mensagem.usecases;

import com.diegorubin.dojos.mensagem.domain.Mensagem;
import com.diegorubin.dojos.mensagem.gateways.NaveMae;
import com.diegorubin.dojos.mensagem.gateways.SubmarinoRusso;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class Traduzir {

    @Autowired
    private NaveMae nave;

    @Autowired
    private SubmarinoRusso submarino;

    void executar() {
        String message = nave.interceptar();

        submarino.enviar(new Mensagem());
    }

}
