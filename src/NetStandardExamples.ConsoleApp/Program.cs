using System;
using Microsoft.Extensions.DependencyInjection;
using NetstandardExamples.Shared;
using System.Linq;

namespace NetStandardExamples.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>();

            

            var serviceProvider  = services.BuildServiceProvider();
            
            
            var dbContext = serviceProvider.GetService<AppDbContext>();
            
            dbContext.Database.EnsureCreated();
            
            var people = dbContext.People.ToList();
            
            Console.WriteLine($"Hello World!  {people.Count} people in the db");
        }
    }
}
