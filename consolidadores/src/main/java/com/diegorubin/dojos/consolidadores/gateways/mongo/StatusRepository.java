package com.diegorubin.dojos.consolidadores.gateways.mongo;

import com.diegorubin.dojos.consolidadores.domain.Status;
import org.springframework.data.mongodb.repository.MongoRepository;

public interface StatusRepository extends MongoRepository<Status, String> {
}
