package com.diegorubin.dojos.consolidadores.domain;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

@Document
public class Status {

    @Id
    private String id;

    private String imei;
    private Integer instante;
    private Float latitude;
    private Float longitude;

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

    public Float getLatitude() {
        return latitude;
    }

    public void setLatitude(Float latitude) {
        this.latitude = latitude;
    }

    public Float getLongitude() {
        return longitude;
    }

    public void setLongitude(Float longitude) {
        this.longitude = longitude;
    }
}
