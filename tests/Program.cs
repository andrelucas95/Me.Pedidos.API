using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace tests
{
    public sealed class Program
    {
        private readonly IConfiguration _configuration;

        public Program()
        {
            BuildPath = Path.Combine("bin", "Debug", "netcoreapp3.1");
            ProjectPath = AppContext.BaseDirectory.Replace(BuildPath, string.Empty);
            ContentPath = ProjectPath.Replace("Tests", "API");

            _configuration = new ConfigurationBuilder()
                .SetBasePath(ProjectPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();
        }

        public string BuildPath { get; }
        public string ProjectPath { get; }
        public string ContentPath { get; }

        public IWebHostBuilder CreateWebHostBuilder() => new WebHostBuilder()
            .UseStartup<Startup>()
            .UseEnvironment("Testing")
            .ConfigureAppConfiguration((builder, config) =>
            {
                builder.HostingEnvironment.ContentRootPath = ProjectPath;
                builder.HostingEnvironment.WebRootPath = ContentPath;
                builder.HostingEnvironment.ContentRootFileProvider = new PhysicalFileProvider(ProjectPath);
                builder.HostingEnvironment.WebRootFileProvider = new PhysicalFileProvider(ContentPath);

                config.AddConfiguration(_configuration);
            });
    }
}
