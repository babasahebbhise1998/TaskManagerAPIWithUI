using Microsoft.EntityFrameworkCore;
using TaskMangerWebAPI.Models;

namespace TaskMangerWebAPI.DataContext
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
