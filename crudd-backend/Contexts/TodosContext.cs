using crudd_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace crudd_backend.Contexts
{
    public class TodosContext : DbContext
    {
        public TodosContext(DbContextOptions<TodosContext> options) : base(options) { }
        public DbSet<TodoModel> Todos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;");
        }
    }
}
