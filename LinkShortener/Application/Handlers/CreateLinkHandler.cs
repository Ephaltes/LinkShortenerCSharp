using System.Threading;
using System.Threading.Tasks;
using LinkShortener.Application.Command;
using LinkShortener.Application.Interface;
using MediatR;

namespace LinkShortener.Application.Handlers
{
    public class CreateLinkHandler : IRequestHandler<CreateLinkCommand,string>
    {
        private readonly IRepository _db;

        public CreateLinkHandler(IRepository db)
        {
            _db = db;
        }

        public async Task<string> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return null;

            if (string.IsNullOrWhiteSpace(request.Link))
                return null;

            return request.Sluge;
        }
    }
}