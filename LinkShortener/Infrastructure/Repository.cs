using System;
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

        public string GetKey(string key)
        {
            try
            {
                var db = _redis.GetDatabase();
                var result = db.StringGet(key);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool SetKey(string key,string value)
        {
            var db = _redis.GetDatabase();
            return db.StringSet(key, value);
        }
    }
}