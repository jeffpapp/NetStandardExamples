using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using NetstandardExamples.Shared;
using System.Linq;

namespace NetStandardExamples.Web
{
    public class Startup
    {

        public Startup(IApplicationEnvironment applicationEnvironment, IRuntimeEnvironment runtimeEnvironment)
        {
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(applicationEnvironment.ApplicationBasePath)
                .AddJsonFile("config.json", true)                
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            
        }

        public IConfiguration Configuration { get; private set; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>();
                
            
        }
        
        public void Configure(IApplicationBuilder app)
        {
            var dbContext= app.ApplicationServices.GetService<AppDbContext>();
            
            dbContext.Database.EnsureCreated();
            
            
            app.Run(context =>
            {
               
                 var requestDbContext = context.RequestServices.GetService<AppDbContext>();
                 
                
                 
                 var people = requestDbContext.People.ToList();
                
                
                
                return context.Response.WriteAsync($"Hello World!  {people.Count} people in the db");
            });
        }
    }
}