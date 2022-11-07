namespace CleanArchitecture.Domain.SeedWork;

public abstract class Response
{
    public List<string> Errors { get; set; } = new List<string>();

    public object Data { get; set; }

    protected Response()
    {
    }

    protected Response(object data)
    {
        Data = data;
    }
}