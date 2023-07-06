namespace Cella.Models;

public class Response
{
    public string Status { get; set; }
    public string Message { get; set; }

    public string? ErrorExceptionMessage { get; set; }
}