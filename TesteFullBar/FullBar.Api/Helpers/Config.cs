using Microsoft.Extensions.Configuration;
using System.IO;

namespace FullBar.Api.Helpers
{
    public class Config
    {
        private static IConfigurationRoot _Configuration { get; set; }

        public static string ConnectionString
        {
            get
            {
                var builder = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot"))
               .AddJsonFile("appsettings.json");

                _Configuration = builder.Build();

                return _Configuration["ConnectionString:DefaultConnection"].ToString();
            }
        }
    
    }
}

