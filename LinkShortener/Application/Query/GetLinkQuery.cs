using LinkShortener.Application.Model;
using MediatR;

namespace LinkShortener.Application.Query
{
    public class GetLinkQuery : IRequest<CustomResponse<string>>
    {
        public string Sluge { get; }

        public GetLinkQuery(string sluge)
        {
            Sluge = sluge;
        }
    }
}