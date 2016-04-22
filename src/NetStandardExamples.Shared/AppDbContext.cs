using Microsoft.EntityFrameworkCore;
using NetstandardExamples.Shared.Entities;

namespace NetstandardExamples.Shared
{
    public class AppDbContext : DbContext
    {
       public DbSet<Person> People { get; set; }
       
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NetStandardExample;Trusted_Connection=True;");
        } 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var personModel = modelBuilder.Entity<Person>();
            
            personModel.HasKey(x => x.PersonId);
            
            personModel.Property(x => x.PersonId).IsRequired().HasDefaultValueSql("newid()");
            
            
        }
    }
    
    
    
}