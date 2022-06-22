<?php

namespace App\Commands;

use App\Domain\Message;

class InterpretarMensagem {

    protected INave $nave;

    protected ISubmarino $submarino;

    public function __construct(INave $nave, ISubmarino $submarino) {
        $this->nave = $nave;
        $this->submarino = $submarino;
    }

    public function execute() {
        $mensagem_da_nave =  $this->nave->interceptarMensagem();

        $subs = mb_substr($mensagem_da_nave, 0,1);

        $mensagem = $mensagem_da_nave;
        if ("β" == $subs){
            $mensagem = new Message("mudanca_posicao");
        }
       
        $this->submarino->enviarMensagem($mensagem);
    }
}