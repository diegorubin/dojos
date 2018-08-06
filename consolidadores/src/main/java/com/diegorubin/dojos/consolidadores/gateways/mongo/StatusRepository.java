package com.diegorubin.dojos.consolidadores.gateways.mongo;

import com.diegorubin.dojos.consolidadores.domain.Status;
import org.springframework.data.domain.Example;
import org.springframework.data.domain.Sort;
import org.springframework.data.mongodb.repository.MongoRepository;

import java.util.List;

public interface StatusRepository extends MongoRepository<Status, String> {
    List<Status> findByImeiAndLatitudeIsNotNullAndLongitudeIsNotNull(String imei, Sort sort);
}
