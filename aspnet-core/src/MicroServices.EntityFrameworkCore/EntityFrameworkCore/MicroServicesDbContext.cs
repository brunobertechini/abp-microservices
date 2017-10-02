using Abp.Zero.EntityFrameworkCore;
using MicroServices.Authorization.Roles;
using MicroServices.Authorization.Users;
using MicroServices.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace MicroServices.EntityFrameworkCore
{
    public class MicroServicesDbContext : AbpZeroDbContext<Tenant, Role, User, MicroServicesDbContext>
    {
        /* Define an IDbSet for each entity of the application */
        
        public MicroServicesDbContext(DbContextOptions<MicroServicesDbContext> options)
            : base(options)
        {

        }
    }
}
