using System;
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
            while (true)
            {
                if (!String.IsNullOrWhiteSpace(request.Sluge) && IsSlugAvailable(request.Sluge))
                {
                    _db.SetKey(request.Sluge, request.Link);
                    return request.Sluge;
                }
                request.CreateSluge();
            }
        }
        
        protected bool IsSlugAvailable(string sluge)
        {
            return String.IsNullOrEmpty(_db.GetKey(sluge));
        }
    }
}