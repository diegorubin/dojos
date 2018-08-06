package com.diegorubin.dojos.consolidadores.fixtures;

import br.com.six2six.fixturefactory.Fixture;
import br.com.six2six.fixturefactory.Rule;
import com.diegorubin.dojos.consolidadores.domain.Status;

public class StatusFixtures {
    public static void load() {
        Fixture.of(Status.class).addTemplate("complete", new Rule() {
            {
                add("imei","111");
                add("latitude", -22.907104);
                add("longitude",-47.063240);
                add("instante",0);
            }
        });

        Fixture.of(Status.class).addTemplate("complete1").inherits("complete", new Rule(){
            {
                add("instante", 1);
                add("latitude", -22.9073);
                add("longitude", -47.063241);
            }
        });

        Fixture.of(Status.class).addTemplate("complete2").inherits("complete", new Rule(){
            {
                add("instante", 2);
            }
        });

        Fixture.of(Status.class).addTemplate("complete3").inherits("complete", new Rule(){
            {
                add("instante", 3);
            }
        });

        Fixture.of(Status.class).addTemplate("sem-latitude").inherits("complete", new Rule(){
            {
                add("latitude", null);
            }
        });

        Fixture.of(Status.class).addTemplate("sem-longitude").inherits("complete", new Rule(){
            {
                add("longitude", null);
            }
        });

       //Fixture.of(Status.class).addTemplate("sem-latitude").inherits("complete", new Rule() {
       //     {
       //         add("latitude", null);
       //         add("instante",1);
       //     }
       // });

    }
}
