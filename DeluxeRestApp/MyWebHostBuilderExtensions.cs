namespace DeluxeRestApp
{
    #region Using statements
    using System;
    using Microsoft.AspNetCore.Hosting;
    #endregion

    public static class MyWebHostBuilderExtensions
    {
        #region Public methods
        public static IWebHostBuilder UseAction(this IWebHostBuilder builder, Action action)
        {
            action();
            return builder;
        }
        #endregion
    }
}
