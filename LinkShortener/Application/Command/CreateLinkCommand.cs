using System.ComponentModel.DataAnnotations;
using MediatR;

namespace LinkShortener.Application.Command
{
    public class CreateLinkCommand : IRequest<string>
    {
        [Required(ErrorMessage = "Invalid Link")]
        public string Link { get; set; }

        public string Sluge { get; set; }
    }
}