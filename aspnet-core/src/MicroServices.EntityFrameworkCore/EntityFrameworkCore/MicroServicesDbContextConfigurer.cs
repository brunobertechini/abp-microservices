using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MicroServices.EntityFrameworkCore
{
    public static class MicroServicesDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MicroServicesDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MicroServicesDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}