package com.diegorubin.dojos.consolidadores.gateways.mongo;

import br.com.six2six.fixturefactory.Fixture;
import com.diegorubin.dojos.consolidadores.ConsolidadoresApplicationTests;
import com.diegorubin.dojos.consolidadores.domain.Status;
import com.diegorubin.dojos.consolidadores.fixtures.FixtureLoader;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;


public class ConsolidadoresGatewayImplIntegrationTest extends ConsolidadoresApplicationTests {

    @Autowired
    StatusRepository statusRepository;

    @Autowired
    ConsolidadoresGatewayImpl consolidadoresGateway;

    @Before
    public void setup() {
        FixtureLoader loader = new FixtureLoader();
        loader.load();
        statusRepository.deleteAll();
    }

    @Test
    public void deveriaRetornarStatusOrdenadosPorInstante() {
        List<Status> listStatus = Fixture.from(Status.class).gimme(4, "complete3", "complete2", "complete", "complete1");

        statusRepository.save(listStatus);

        List<Status> listStatusReturn = consolidadoresGateway.findByImei("111");

        List<Integer> expected = listStatusReturn.stream().map(Status::getInstante).collect(Collectors.toList());

        Assert.assertEquals(Arrays.asList(0, 1, 2, 3), expected);


    }

    @Test
    public void naoDeveriaRetornarSemCoordenadas(){
        List<Status> listStatus = Fixture.from(Status.class).gimme(3, "complete", "sem-latitude", "sem-longitude");

        statusRepository.save(listStatus);

        List<Status> listStatusReturn = consolidadoresGateway.findByImei("111");

        Assert.assertEquals(1, listStatusReturn.size());
        Assert.assertNotNull(listStatusReturn.get(0).getLatitude());
        Assert.assertNotNull(listStatusReturn.get(0).getLongitude());
    }
}

