package com.diegorubin.dojos.consolidadores.gateways.mongo;

import com.diegorubin.dojos.consolidadores.domain.Status;
import com.diegorubin.dojos.consolidadores.gateways.ConsolidadoresGateway;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ConsolidadoresGatewayImpl implements ConsolidadoresGateway {

    @Override
    public List<Status> findByImei(String imei) {
        return null;
    }

}
