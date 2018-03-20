package com.diegorubin.dojos.consolidadores.gateways.mongo;

import com.diegorubin.dojos.consolidadores.ConsolidadoresApplicationTests;
import com.diegorubin.dojos.consolidadores.fixtures.FixtureLoader;
import org.junit.Before;
import org.junit.Test;


public class ConsolidadoresGatewayImplIntegrationTest extends ConsolidadoresApplicationTests {



    @Before
    public void setup() {
        FixtureLoader loader = new FixtureLoader();
        loader.load();

    }

    @Test
    public void deveriaRetornarSomenteOsPontosComLatitudeELongitude() {

    }
}
