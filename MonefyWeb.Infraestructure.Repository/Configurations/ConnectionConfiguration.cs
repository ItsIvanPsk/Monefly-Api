using Microsoft.Extensions.Configuration;

namespace MonefyWeb.Infraestructure.Repository
{
    public class ConnectionConfiguration : IConnectionConfiguration
    {
        private readonly IConfiguration _configuration;

        public ConnectionConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration.GetConnectionString("SQLDatabase");

    }
}
