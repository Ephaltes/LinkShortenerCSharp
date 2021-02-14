namespace LinkShortener.Application.Interface
{
    public interface IRepository
    {
        public string GetKey(string key);
        public bool SetKey(string key,string value);
    }
}