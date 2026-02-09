package com.example.carapi.controller;

import com.example.carapi.model.Equipo;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@WebMvcTest(EquipoController.class)
class EquipoControllerTest {

    @Autowired
    private MockMvc mockMvc;

    @Test
    void getAllEquipos_shouldReturnListOfEquipos() throws Exception {
        mockMvc.perform(get("/equipos"))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(content().json("[\n" +
                        "  {\"id\":\"1\",\"nombre\":\"Real Madrid\",\"ciudad\":\"Madrid\",\"fundacion\":1902},\n" +
                        "  {\"id\":\"2\",\"nombre\":\"Barcelona\",\"ciudad\":\"Barcelona\",\"fundacion\":1899}\n" +
                        "]"));
    }

    @Test
    void addEquipo_shouldAddEquipoToList() throws Exception {
        String newEquipoJson = "{\"id\":\"3\",\"nombre\":\"Atletico Madrid\",\"ciudad\":\"Madrid\",\"fundacion\":1903}";

        mockMvc.perform(post("/equipos")
                        .contentType(MediaType.APPLICATION_JSON)
                        .content(newEquipoJson))
                .andExpect(status().isOk())
                .andExpect(content().json(newEquipoJson));
    }
}
