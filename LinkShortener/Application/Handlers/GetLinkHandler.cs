using System.Threading;
using System.Threading.Tasks;
using LinkShortener.Application.Interface;
using LinkShortener.Application.Model;
using LinkShortener.Application.Query;
using MediatR;

namespace LinkShortener.Application.Handlers
{
    public class GetLinkHandler : IRequestHandler<GetLinkQuery,CustomResponse<string>>
    {
        private readonly IRepository _db;
        
        public GetLinkHandler(IRepository db)
        {
            _db = db;
        }
        
        public async Task<CustomResponse<string>> Handle(GetLinkQuery request, CancellationToken cancellationToken)
        {
            var result = await _db.GetKeyAsync(request.Sluge);

            if (string.IsNullOrWhiteSpace(result))
                return CustomResponse.Error<string>(400,"Sluge unknown");

            return CustomResponse.Success(result);
        }
    }
}