namespace LiatrioPoC.Web
{
    public interface IAppConfiguration
    {
        string ApiUrl { get; }
    }

    public class AppConfiguration : IAppConfiguration
    {
        private IConfiguration _configuration;

        public AppConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ApiUrl => _configuration["ApiUrl"] ?? "";
    }
}
