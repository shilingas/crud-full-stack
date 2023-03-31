using crudd_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace crudd_backend.Contexts
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options): base(options) { }
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;");
        }
    }
}
