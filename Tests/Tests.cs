using System;
using System.Linq;
using System.Threading.Tasks;
using Conversion;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Theory]
        [InlineData(1, false)]
        [InlineData(1, true)]
        public async Task RequestShouldNotThrow(long value, bool inMemory)
        {
            if (!inMemory) await EnsureTablesAreEmpty();

            using (var context = GetMyContext(isInMemory: inMemory))
            {
                context.MyTables.Add(new MyTable
                {
                    MyProperty = (MyProperty)value,
                });
                await context.SaveChangesAsync();
            }

            using (var context = GetMyContext(isInMemory: inMemory))
            {
                var _ = context.MyTables.Where(o => o.MyProperty == value).ToList();
            }

            async Task EnsureTablesAreEmpty()
            {
                using var context = GetMyContext(isInMemory: false);
                var objets = context.MyTables.ToList();
                context.MyTables.RemoveRange(objets);
                await context.SaveChangesAsync();
            }
        }

        private MyContext GetMyContext(bool isInMemory) => new MyContext(GetMyOptions(isInMemory));

        private DbContextOptions<MyContext> GetMyOptions(bool isInMemory = true) => isInMemory
                ? new DbContextOptionsBuilder<MyContext>()
                    .UseInMemoryDatabase(_databaseName)
                    .Options
                : new DbContextOptionsBuilder<MyContext>()
                    .UseSqlServer(ConnectionString)
                    .Options;

        private readonly string _databaseName = $"testDb_{Guid.NewGuid()}";
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    }
}
