using Microsoft.EntityFrameworkCore;

namespace Conversion
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MyTable>().Property(o => o.MyProperty).HasObjetIdConversion();
            builder.Entity<MyTable>().Property(o => o.MyProperty).IsRequired();
            builder.Entity<MyTable>().HasIndex(o => o.MyProperty).IsUnique();
        }

        public DbSet<MyTable> MyTables { get; set; }
    }
}
