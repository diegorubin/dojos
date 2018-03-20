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
    }
}
