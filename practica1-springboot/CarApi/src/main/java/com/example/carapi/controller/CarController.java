package com.example.carapi.controller;

import com.example.carapi.model.Car;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/cars")
@Tag(name = "Car Controller", description = "Manage car data")
public class CarController {

    private final List<Car> cars = new ArrayList<>();

    public CarController() {
        cars.add(new Car("1", "Toyota", "Corolla", 2020));
        cars.add(new Car("2", "Honda", "Civic", 2019));
    }

    @Operation(summary = "Get all cars", description = "Retrieve a list of all cars")
    @GetMapping
    public List<Car> getAllCars() {
        return cars;
    }

    @Operation(summary = "Add a new car", description = "Add a new car to the list")
    @PostMapping
    public Car addCar(@RequestBody Car car) {
        cars.add(car);
        return car;
    }
}