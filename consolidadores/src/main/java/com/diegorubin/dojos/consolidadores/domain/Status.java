package com.diegorubin.dojos.consolidadores.domain;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

@Document
public class Status {

    @Id
    private String id;

    private String imei;
    private Integer instante;
    private Double latitude;
    private Double longitude;

    public String getImei() {
        return imei;
    }

    public void setImei(String imei) {
        this.imei = imei;
    }

    public Integer getInstante() {
        return instante;
    }

    public void setInstante(Integer instante) {
        this.instante = instante;
    }

    public Double getLatitude() {
        return latitude;
    }

    public void setLatitude(Double latitude) {
        this.latitude = latitude;
    }

    public Double getLongitude() {
        return longitude;
    }

    public void setLongitude(Double longitude) {
        this.longitude = longitude;
    }
}
