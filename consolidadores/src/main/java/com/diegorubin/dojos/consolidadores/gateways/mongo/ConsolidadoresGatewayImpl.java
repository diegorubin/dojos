package com.diegorubin.dojos.consolidadores.gateways.mongo;

import com.diegorubin.dojos.consolidadores.domain.Status;
import com.diegorubin.dojos.consolidadores.gateways.ConsolidadoresGateway;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Sort;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ConsolidadoresGatewayImpl implements ConsolidadoresGateway {

    @Autowired
    StatusRepository statusRepository;


    @Override
    public List<Status> findByImei(String imei) {
        Sort sort = new Sort(Sort.Direction.ASC, "instante");
        return statusRepository.findByImeiAndLatitudeIsNotNullAndLongitudeIsNotNull(imei,sort);

    }

}
