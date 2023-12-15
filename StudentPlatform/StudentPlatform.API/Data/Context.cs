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

        public string DbPath {get;}


           public Context(DbContextOptions<Context> options) : base(options) {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "studentplatform.db");
        } 
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("StudentPlatformConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
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
