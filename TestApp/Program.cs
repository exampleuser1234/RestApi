using System;
using GithubServices;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new GithubCardsProvider();
            //var res = provider.Get("1383654").Result;
            var res2 = provider.Edit("4282107", "twoja mama").Result;

            //var res3 = provider.Get("1383654", "dupa").Result;
            Console.WriteLine("something");
        }
    }
}
