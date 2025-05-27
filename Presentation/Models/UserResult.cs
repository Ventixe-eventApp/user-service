namespace Presentation.Models;

public class UserResult
{
    public bool Succeeded { get; set; }
    public int StatusCode { get; set; }
    public string? Error { get; set; }

}

public class UserResult<T> : UserResult
{
    public T? Result { get; set; }

}
