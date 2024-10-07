using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace TodoListProject.Web.Data
{
    public class TodosDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public TodosDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
