using Microsoft.EntityFrameworkCore;

namespace School.Models
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public ApplicationContext(DbContextOptions options): base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
