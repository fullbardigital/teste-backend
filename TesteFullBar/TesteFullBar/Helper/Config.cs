using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFullBar.Helpers
{
    public class Config
    {
        private static IConfigurationRoot _Configuration { get; set; }

        public static string UrlAPI
        {
            get
            {
                var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

                //Obtem Serializa o json
                _Configuration = builder.Build();

                //Obtem a propriedade configurada
                return _Configuration["UrlAPI:FullBar"].ToString();
            }
        }
    }
}
