using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace WebAdvert.SearchWorker
{
    public static class ConfigurationHelper
    {
        private static IConfiguration _configuration;

        public static IConfiguration Instance
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration =
                        new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", false)
                            .Build();
                }

                return _configuration;
            }
        }
    }
}
