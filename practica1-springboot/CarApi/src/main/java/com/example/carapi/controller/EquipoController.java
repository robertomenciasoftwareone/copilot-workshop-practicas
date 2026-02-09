package com.example.carapi.controller;

import com.example.carapi.model.Equipo;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.tags.Tag;

@RestController
@RequestMapping("/equipos")
@Tag(name = "Equipo Controller", description = "Manage equipo data")
public class EquipoController {

    private final List<Equipo> equipos = new ArrayList<>();

    public EquipoController() {
        equipos.add(new Equipo("1", "Real Madrid", "Madrid", 1902));
        equipos.add(new Equipo("2", "Barcelona", "Barcelona", 1899));
    }

    @Operation(summary = "Get all equipos", description = "Retrieve a list of all equipos")
    @GetMapping
    public List<Equipo> getAllEquipos() {
        return equipos;
    }

    @Operation(summary = "Add a new equipo", description = "Add a new equipo to the list")
    @PostMapping
    public Equipo addEquipo(@RequestBody Equipo equipo) {
        equipos.add(equipo);
        return equipo;
    }
}
