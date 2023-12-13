using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentPlatform.API.Models;

namespace StudentPlatform.API.Data
{
    public class Context : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public Context() : base()
        {

            DbContextOptionsBuilder<Context> optionsBuilder = new DbContextOptionsBuilder<Context>();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Jens1DB;User Id=sa;Password=sdkSKd1234;MultipleActiveResultSets=true;Encrypt=false");
            }
        }
    }
}
