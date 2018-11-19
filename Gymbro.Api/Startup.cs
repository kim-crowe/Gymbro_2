using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marten;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Gymbro.Api
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
            var dbHost = Configuration.GetValue<string>("DB_HOST") ?? "localhost";
            var dbPort = Configuration.GetValue<string>("DB_PORT") ?? "5431";

            var documentStore = DocumentStore.For($"Server={dbHost};Port={dbPort};User Id=postgres;Password=admin;Database=postgres;");
            services.AddSingleton<IDocumentStore>(documentStore);
            services.AddScoped<IUserContext, TempUserContext>();                
            services.AddScoped<IUserProfileStore, MartonUserProfileStore>();
            services.AddScoped<IExerciseRecordStore, MartonExerciseRecordStore>();
            services.AddMvc(opts => opts.Filters.Add(new AllowAnonymousFilter()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
