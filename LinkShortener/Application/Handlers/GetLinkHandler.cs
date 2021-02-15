using System.Threading;
using System.Threading.Tasks;
using LinkShortener.Application.Interface;
using LinkShortener.Application.Query;
using MediatR;

namespace LinkShortener.Application.Handlers
{
    public class GetLinkHandler : IRequestHandler<GetLinkQuery,string>
    {
        private readonly IRepository _db;
        
        public GetLinkHandler(IRepository db)
        {
            _db = db;
        }
        
        public async Task<string> Handle(GetLinkQuery request, CancellationToken cancellationToken)
        {
            var result = _db.GetKey(request.Sluge);

            if (string.IsNullOrWhiteSpace(result))
                return null;

            return result;
        }
    }
}