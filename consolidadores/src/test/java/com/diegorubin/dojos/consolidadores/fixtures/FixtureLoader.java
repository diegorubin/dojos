package com.diegorubin.dojos.consolidadores.fixtures;

import br.com.six2six.fixturefactory.loader.TemplateLoader;

public class FixtureLoader implements TemplateLoader {

    @Override
    public void load() {
        StatusFixtures.load();
    }
}
