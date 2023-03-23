

using Microsoft.EntityFrameworkCore;

namespace Task1.UserData
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext>options): base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Location> locations { get; set; }
    }
}
