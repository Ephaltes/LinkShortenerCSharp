using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LinkShortener.Application.Interface;
using LinkShortener.Infrastructure;
using MediatR;

namespace LinkShortener.Application.Command
{
    public class CreateLinkCommand : IRequest<string>
    {
        [Required(ErrorMessage = "Invalid Link")]
        public string Link { get; set; }

        public string Sluge { get; set; }
        
        private static Random random = new Random();
        
        public string CreateSluge()
        {
            Sluge = RandomString();
            return Sluge;
        }
        
        protected static string RandomString(int minlength=4,int maxlength=8)
        {
            int length = random.Next(minlength, maxlength + 1);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}