using CleanArchitecture.Domain.SeedWork;

namespace CleanArchitecture.Application.Queries;

public class QueryResponse : Response
{
    public QueryResponse()
    {
    }

    public QueryResponse(object data) : base(data)
    {
    }
}