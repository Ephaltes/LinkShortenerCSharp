using System;
using FluentValidation;
using LinkShortener.Application.Command;
using LinkShortener.Application.Query;

namespace LinkShortener.Application.Validation
{
    public class GetLinkQueryValidator : AbstractValidator<GetLinkQuery>
    {
        public GetLinkQueryValidator()
        {
            RuleFor(x => x.Sluge)
                .NotEmpty()
                .WithMessage("Sluge is empty");
        }
    }
}