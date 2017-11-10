using Auction.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.API
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // TODO: aufofac registerations (http://autofac.readthedocs.io/en/latest/integration/aspnetcore.html)
        // TODO: iunitOfWork registeration as Scoped to the HTTP\Bus context (single UnitofWork per call)
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<AuctionContext>(options =>
                {
                    options.UseSqlServer(_configuration["ConnectionString"], builder =>
                    {
                        builder.MigrationsAssembly(typeof(AuctionContext).Assembly.GetName().Name);
                        //builder.EnableRetryOnFailure()
                    });

                }, ServiceLifetime.Scoped);
        }

        public void Configure(IApplicationBuilder app)
        {
            
            //app.UseMvc();
        }
    
    }
}