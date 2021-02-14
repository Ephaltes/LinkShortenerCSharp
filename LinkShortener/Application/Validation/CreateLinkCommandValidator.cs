using System;
using FluentValidation;
using LinkShortener.Application.Command;

namespace LinkShortener.Application.Validation
{
    public class CreateLinkCommandValidator : AbstractValidator<CreateLinkCommand>
    {
        public CreateLinkCommandValidator()
        {
            RuleFor(x => x.Link)
                .NotEmpty()
                .Must(IsUri);
        }

        private bool IsUri(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            //Courtesy of @Pure.Krome's comment and https://stackoverflow.com/a/25654227/563532
            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}