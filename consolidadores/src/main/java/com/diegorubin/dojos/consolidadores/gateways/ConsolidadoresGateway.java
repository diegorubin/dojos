package com.diegorubin.dojos.consolidadores.gateways;

import com.diegorubin.dojos.consolidadores.domain.Status;

import java.util.List;

public interface ConsolidadoresGateway {
    List<Status> findByImei(String imei);
}
