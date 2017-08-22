using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace DeluxeRestApp
{
    public static class MyWebHostBuilderExtensions
    {
        public static IWebHostBuilder UseInit(this IWebHostBuilder builder, Action action)
        {
            action();
            return builder;
        }
    }
}
