using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GithubServices;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Environment = GithubServices.Environment;

namespace DeluxeRestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args[0] == null)
                return;
            Environment.AuthToken = args[0];
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseInit(()=> { Environment.Init(new GithubProjectsProvider(), new GithubColumnsProvider()).Wait(); })
                .Build();
    }
}
