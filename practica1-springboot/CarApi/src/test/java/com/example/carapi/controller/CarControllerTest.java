package com.example.carapi.controller;

import com.example.carapi.model.Car;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@WebMvcTest(CarController.class)
class CarControllerTest {

    @Autowired
    private MockMvc mockMvc;

    @Test
    void getAllCars_shouldReturnListOfCars() throws Exception {
        mockMvc.perform(get("/cars"))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(content().json("[\n" +
                        "  {\"id\":\"1\",\"brand\":\"Toyota\",\"model\":\"Corolla\",\"year\":2020},\n" +
                        "  {\"id\":\"2\",\"brand\":\"Honda\",\"model\":\"Civic\",\"year\":2019}\n" +
                        "]"));
    }

    @Test
    void addCar_shouldAddCarToList() throws Exception {
        String newCarJson = "{\"id\":\"3\",\"brand\":\"Ford\",\"model\":\"Focus\",\"year\":2021}";

        mockMvc.perform(post("/cars")
                        .contentType(MediaType.APPLICATION_JSON)
                        .content(newCarJson))
                .andExpect(status().isOk())
                .andExpect(content().json(newCarJson));
    }
}