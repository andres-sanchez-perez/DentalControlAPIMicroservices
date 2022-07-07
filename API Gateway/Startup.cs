using API_Gateway.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.Authorization;
using Ocelot.DependencyInjection;
using Ocelot.DownstreamRouteFinder.Middleware;
using Ocelot.DownstreamUrlCreator.Middleware;
using Ocelot.Errors.Middleware;
using Ocelot.LoadBalancer.Middleware;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;
using Ocelot.Request.Middleware;
using Ocelot.Requester.Middleware;
using Ocelot.RequestId.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Gateway
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseOcelot((ocelotBuilder, ocelotConfiguration) => {
                // this sets up the downstream context and gets the config
                app.UseDownstreamContextMiddleware();
                // This is registered to catch any global exceptions that are not handled
                // It also sets the Request Id if anything is set globally
                ocelotBuilder.UseExceptionHandlerMiddleware();

                // This is registered first so it can catch any errors and issue an appropriate response
                //ocelotBuilder.UseResponderMiddleware();
                ocelotBuilder.UseMiddleware<MiddlewareClass>();

                ocelotBuilder.UseDownstreamRouteFinderMiddleware();
                ocelotBuilder.UseMultiplexingMiddleware();
                ocelotBuilder.UseDownstreamRequestInitialiser();
                ocelotBuilder.UseRequestIdMiddleware();

                
                //ocelotBuilder.UseMiddleware();

                ocelotBuilder.UseLoadBalancingMiddleware();
                ocelotBuilder.UseDownstreamUrlCreatorMiddleware();
                ocelotBuilder.UseHttpRequesterMiddleware();
            }).Wait();
        }
    }
}
