package dev.diegorubin.httpparser;

class HTTPParser {

    private String method;
    private String path;

    public String getMethod() {
        return method;
    }

    public void setMethod(String method) {
        this.method = method;
    }

    public String getPath() {
        return path;
    }

    public void setPath(String path) {
        this.path = path;
    }

    public void parse(final String content) {
        // do parse //
    }
}
