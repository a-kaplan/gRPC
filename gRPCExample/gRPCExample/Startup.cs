﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPCExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddSingleton<GreeterService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSession();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(@"Communication with gRPC
endpoints must be made through a gRPC client.
To learn how to create a client,
visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
