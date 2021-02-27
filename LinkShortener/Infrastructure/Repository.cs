using System;
using System.Threading.Tasks;
using LinkShortener.Application.Interface;
using StackExchange.Redis;

namespace LinkShortener.Infrastructure
{
    public class Repository : IRepository
    {
        //public static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

        private readonly ConnectionMultiplexer _redis;

        public Repository(ConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task<string> GetKeyAsync(string key)
        {
            try
            {
                var db = _redis.GetDatabase();
                var result = await db.StringGetAsync(key);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> SetKeyAsync(string key,string value)
        {
            var db = _redis.GetDatabase();
            return await db.StringSetAsync(key, value);
        }
    }
}