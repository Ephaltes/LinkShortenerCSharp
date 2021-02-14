using MediatR;

namespace LinkShortener.Application.Query
{
    public class GetLinkQuery : IRequest<string>
    {
        public string Sluge { get; }

        public GetLinkQuery(string sluge)
        {
            Sluge = sluge;
        }
    }
}