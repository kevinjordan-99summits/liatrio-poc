namespace LiatrioPoC.Api
{
    public interface IAppConfiguration
    {

    }

    public class AppConfiguration : IAppConfiguration
    {
        protected IConfiguration Configuration;

        public AppConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
