namespace Infrastructure.CrossCutting.Environment
{
    public class Service
    {
        public string Token { get; private set; }
        public string Url { get; private set; }

        public Service(string token, string url)
        {
            Token = token;
            Url = url;
        }
    }
}