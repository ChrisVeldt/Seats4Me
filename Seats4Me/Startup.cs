using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Seats4Me.BusinessLogic.Interfaces;
using Seats4Me.BusinessLogic.Services;
using Seats4Me.Common.Utils;
using Seats4Me.DataAccess.Context;
using Seats4Me.DataAccess.Interfaces;
using Seats4Me.DataAccess.Migrations;
using Seats4Me.DataAccess.Repositories;

namespace Seats4Me
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<IUrlHelper>(factory =>
            {
                var actionContext = factory.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });

            var configSection = Configuration.GetSection("ConnectionStrings");
            var connectionString = configSection.GetSection("Seats4Me").Value;

            var optionsBuilder = new DbContextOptionsBuilder();
            var contextOptions = optionsBuilder.UseSqlServer(connectionString).Options;
            services.AddSingleton(contextOptions);

            var configSectionApp = new Seats4MeConfiguration();
            (Configuration.GetSection("Seats4Me")).Bind(configSectionApp);
            services.AddSingleton(configSectionApp);

            // todo: Is this the best place for seeding?
            var context = new Seats4MeContext(contextOptions);
            InitializeDb.Seed(context);

            services.AddScoped<Seats4MeContext, Seats4MeContext>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IShowRepository, ShowRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IShowService, ShowService>();
            services.AddScoped<ITicketService, TicketService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
