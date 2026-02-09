package com.example.carapi.model;

public class Equipo {
    private String id;
    private String nombre;
    private String ciudad;
    private int fundacion;

    public Equipo(String id, String nombre, String ciudad, int fundacion) {
        this.id = id;
        this.nombre = nombre;
        this.ciudad = ciudad;
        this.fundacion = fundacion;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getCiudad() {
        return ciudad;
    }

    public void setCiudad(String ciudad) {
        this.ciudad = ciudad;
    }

    public int getFundacion() {
        return fundacion;
    }

    public void setFundacion(int fundacion) {
        this.fundacion = fundacion;
    }
}
