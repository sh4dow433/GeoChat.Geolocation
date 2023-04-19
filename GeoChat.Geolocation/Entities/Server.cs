public class Server {
    public long id { get; set; }
    public String name { get; set; }
    public String url { get; set; }

    public Server(long id, String name, String url) { 
        this.id = id;
        this.name = name;
        this.url = url;
    }
}