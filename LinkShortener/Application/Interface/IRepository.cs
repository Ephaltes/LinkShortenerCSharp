using System.Threading.Tasks;

namespace LinkShortener.Application.Interface
{
    public interface IRepository
    {
        public Task<string> GetKeyAsync(string key);
        public Task<bool> SetKeyAsync(string key,string value);
    }
}