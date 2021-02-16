package dev.diegorubin.httpparser;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.Test;

class HTTPParserTest {

    @Test
    public void shouldGetMethod() {
        String content = "GET / HTTP/1.1";

        HTTPParser parser = new HTTPParser();
        parser.parse(content);

        assertEquals("GET", parser.getMethod());

    }
}
