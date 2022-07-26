public enum ResultType {
    User,
    Community
}

public class SearchCompletion {
    public int id { get; set; }
    public string name { get; set; } = null!;
    public ResultType type { get; set; }
}