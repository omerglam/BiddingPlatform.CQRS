using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Auction.API
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //Todo: use self host + TopShelf as a windows service
        //        
        //}

        //TODO: change project template (Asp.net core) to deal with libuv error (https://github.com/aspnet/KestrelHttpServer/issues/1292#issuecomment-278871702)
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
       
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddJsonFile("settings.json");
                }).UseKestrel(kestreloptions =>
                {
                    kestreloptions.Listen(IPAddress.Loopback,5001);
                })
                .Build();
    }
}
