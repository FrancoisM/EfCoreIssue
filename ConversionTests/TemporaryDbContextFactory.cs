using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Conversion
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public MyContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .Build();
            var builder = new DbContextOptionsBuilder<MyContext>();
            builder.UseSqlServer(ConnectionString, b => b.MigrationsAssembly("Conversion").CommandTimeout((int)TimeSpan.FromMinutes(180).TotalSeconds));
            return new MyContext(builder.Options);
        }
    }
}