package com.diegorubin.dojos.consolidadores;

import com.github.fakemongo.Fongo;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;
import org.springframework.data.mongodb.MongoDbFactory;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.data.mongodb.core.SimpleMongoDbFactory;

@Configuration
@PropertySource("classpath:application.properties")
@ComponentScan({"com.diegorubin.dojos.consolidadores"})
public class ConsolidadoresIntegrationTestConfiguration {
    private static final String DATABASE_NAME = "integration-tests";

    @Bean
    public MongoTemplate mongoTemplate() {
        final MongoTemplate mongoTemplate = new MongoTemplate(mongoDbFactory());
        return mongoTemplate;
    }

    public MongoDbFactory mongoDbFactory() {
        final Fongo fongo = new Fongo("mongodb server in memory");
        return new SimpleMongoDbFactory(fongo.getMongo(), DATABASE_NAME);
    }
}
