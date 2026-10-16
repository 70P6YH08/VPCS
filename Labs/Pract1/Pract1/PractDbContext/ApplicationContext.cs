using Microsoft.EntityFrameworkCore;

namespace Pract1.PractDbContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) =>
           Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                 new Car { Id = 1, Model = "Mark2", Mark = "Toyota", Vin = "asdu9has9fhaev", Color = "Green" },
                 new Car { Id = 2, Model = "Kalina", Mark = "Lada", Vin = "2fvaeffhaev", Color = "Pink" },
                 new Car { Id = 3, Model = "acer", Mark = "asdasd", Vin = "334b5tewshaev", Color = "Yellow" },
                 new Car { Id = 4, Model = "vs6rt", Mark = "234da", Vin = "bga45YHSTfhaev", Color = "White" },
                 new Car { Id = 5, Model = "536h3b5", Mark = "4vw24", Vin = "AN5YABTRhaev", Color = "Blue" }
            );
        }
    }
}
