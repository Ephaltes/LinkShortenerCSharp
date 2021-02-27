using System;
using System.Threading;
using System.Threading.Tasks;
using LinkShortener.Application.Command;
using LinkShortener.Application.Interface;
using LinkShortener.Application.Model;
using MediatR;

namespace LinkShortener.Application.Handlers
{
    public class CreateLinkHandler : IRequestHandler<CreateLinkCommand,CustomResponse<string>>
    {
        private readonly IRepository _db;

        public CreateLinkHandler(IRepository db)
        {
            _db = db;
        }

        public async Task<CustomResponse<string>> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
        {

            if (request.CustomSluge 
                && (String.IsNullOrWhiteSpace(request.Sluge) 
                    ||  ! await IsSlugAvailable(request.Sluge))
                )
                return CustomResponse.Error<string>(400,"Slug not available");

            if (!request.CustomSluge)
            {
                while (true)
                {
                    if (!String.IsNullOrWhiteSpace(request.Sluge) 
                        && await IsSlugAvailable(request.Sluge))
                    {
                        await _db.SetKeyAsync(request.Sluge, request.Link);
                        return CustomResponse.Success(request.Sluge);
                    }
                    request.CreateSluge();
                }
            }

            await _db.SetKeyAsync(request.Sluge, request.Link);
            return CustomResponse.Success(request.Sluge);
        }
        
        protected async Task<bool> IsSlugAvailable(string sluge)
        {
            return String.IsNullOrEmpty(await _db.GetKeyAsync(sluge));
        }
    }
}