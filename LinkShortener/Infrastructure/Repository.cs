using System;
using LinkShortener.Application.Interface;
using StackExchange.Redis;

namespace LinkShortener.Infrastructure
{
    public class Repository : IRepository
    {
        public static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
        
        public string GetKey(string key)
        {
            try
            {
                var db = redis.GetDatabase();
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
            var db = redis.GetDatabase();
            return db.StringSet(key, value);
        }
    }
}