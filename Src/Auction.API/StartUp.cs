using System;
using Auction.API.Infrastructure;
using Auction.Infrastructure;
using Autofac;
using Autofac.Extensions.DependencyInjection;
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
        // TODO: create hosted service to consume awaiting messages to send to the bus (Outbox)
        public IServiceProvider ConfigureServices(IServiceCollection services)
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

            services.AddMvc().AddControllersAsServices();

            var container = new ContainerBuilder();

            container.Populate(services);
            container.RegisterModule<MediatRModule>();
            container.RegisterModule<AuctionApiModule>();

            return new AutofacServiceProvider(container.Build());
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            //app.UseMvc();
        }
    
    }
}