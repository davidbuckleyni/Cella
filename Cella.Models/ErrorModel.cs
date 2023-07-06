using System;
using System.Net;

namespace Cella.Models;

public class ErrorModel
{
    
    public string? EventName { get; set; }
    public string ErrorMessage { get; set; }
    public DateTime? ErrorDate { get; set; }

    public HttpStatusCode? StatusCode { get; set; }
    public string? Json { get; set; }
}