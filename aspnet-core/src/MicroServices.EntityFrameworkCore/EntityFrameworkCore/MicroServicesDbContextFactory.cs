using MicroServices.Configuration;
using MicroServices.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MicroServices.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MicroServicesDbContextFactory : IDesignTimeDbContextFactory<MicroServicesDbContext>
    {
        public MicroServicesDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MicroServicesDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MicroServicesDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MicroServicesConsts.ConnectionStringName));

            return new MicroServicesDbContext(builder.Options);
        }
    }
}