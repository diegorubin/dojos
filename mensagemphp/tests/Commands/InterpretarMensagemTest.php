<?php

namespace App\Commands;

use PHPUnit\Framework\TestCase;
use App\Commands\InterpretarMensagem;
use App\Domain\Message;

final class InterpretarMensagemTest extends TestCase
{
    public function testReceberInterceptarMensagem() {

        $nave = $this->getMockBuilder(INave::class)
                 ->setMethods(['interceptarMensagem'])
                 ->getMock();

        $submarino = $this->getMockBuilder(ISubmarino::class)
                      ->setMethods(['enviarMensagem'])
                      ->getMock();

        $mensagem = "mensagem";
        $nave->method("interceptarMensagem")->willReturn($mensagem);

        $submarino->expects($this->once())->method("enviarMensagem")->with($mensagem);

        $interpretador = new InterpretarMensagem($nave, $submarino);
        $interpretador->execute();
    }

    public function testInterpretarMensagem() {

        $nave = $this->getMockBuilder(INave::class)
                 ->setMethods(['interceptarMensagem'])
                 ->getMock();

        $submarino = $this->getMockBuilder(ISubmarino::class)
                      ->setMethods(['enviarMensagem'])
                      ->getMock();

        $mensagem = "βφ1ι2";
        $nave->method("interceptarMensagem")->willReturn($mensagem);

        $mensagem_interpretada = new Message("mudanca_posicao");
        $submarino->expects($this->once())->method("enviarMensagem")->with($mensagem_interpretada);

        $interpretador = new InterpretarMensagem($nave, $submarino);
        $interpretador->execute();
    }

    public function testInterpretarMensagemMudancaPosicaoComPonto() {

        $nave = $this->getMockBuilder(INave::class)
                 ->setMethods(['interceptarMensagem'])
                 ->getMock();

        $submarino = $this->getMockBuilder(ISubmarino::class)
                      ->setMethods(['enviarMensagem'])
                      ->getMock();

        $mensagem = "βφ1ι2";
        $nave->method("interceptarMensagem")->willReturn($mensagem);

        $mensagem_interpretada = new Message("mudanca_posicao");
        $mensagem_interpretada->ponto = [1,2];
        
        $submarino->expects($this->once())->method("enviarMensagem")->with($mensagem_interpretada);

        $interpretador = new InterpretarMensagem($nave, $submarino);
        $interpretador->execute();
    }
}
