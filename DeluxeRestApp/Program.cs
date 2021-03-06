﻿using GithubServices;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Environment = GithubServices.Environment;

namespace DeluxeRestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:5000")
                .UseAction(()=> { Environment.Init(new GithubProjectsProvider(), new GithubColumnsProvider()).Wait(); })
                .Build();
    }
}
