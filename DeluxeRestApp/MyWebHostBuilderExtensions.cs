namespace DeluxeRestApp
{
    #region Usings
    using System;
    using Microsoft.AspNetCore.Hosting;
    #endregion

    public static class MyWebHostBuilderExtensions
    {
        #region Public methods
        public static IWebHostBuilder UseInit(this IWebHostBuilder builder, Action action)
        {
            action();
            return builder;
        }
        #endregion
    }
}
