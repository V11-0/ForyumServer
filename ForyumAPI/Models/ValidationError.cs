namespace ForyumAPI.Models;

public class ValidationError {

    public ValidationError(string field, string error) {
        Field = field;
        Error = error;
    }

    public string Field { get; set; } = null!;
    public string Error { get; set; } = null!;
}