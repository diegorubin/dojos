<?php

namespace App\Domain;

class Message
{
    public $tipo = '';

    public function __construct($tipo) {
        $this->tipo = $tipo;
    }
}

