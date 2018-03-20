package com.diegorubin.dojos.consolidadores;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.data.mongodb.repository.config.EnableMongoRepositories;

@SpringBootApplication
@EnableMongoRepositories
public class ConsolidadoresApplication {

	public static void main(String[] args) {
		SpringApplication.run(ConsolidadoresApplication.class, args);
	}
}
