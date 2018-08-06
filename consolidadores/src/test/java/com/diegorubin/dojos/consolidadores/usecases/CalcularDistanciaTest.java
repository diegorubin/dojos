package com.diegorubin.dojos.consolidadores.usecases;


import com.diegorubin.dojos.consolidadores.domain.Status;
import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.runners.MockitoJUnitRunner;

import java.util.ArrayList;
import java.util.List;

@RunWith(MockitoJUnitRunner.class)
public class CalcularDistanciaTest {

    @InjectMocks
    CalcularDistancia calcularDistancia;

    @Test
    public void calculaDistanciaTest(){
        List<Status> listStatus = new ArrayList<>();

        Double distanciaPercorrida = calcularDistancia.calcular(listStatus);

        Assert.assertEquals(Double.valueOf(0), distanciaPercorrida);
    }

}

