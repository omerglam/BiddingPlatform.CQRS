using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Auction.API
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //Todo: use self host + TopShelf as a windows service
        //        
        //}

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
       
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
