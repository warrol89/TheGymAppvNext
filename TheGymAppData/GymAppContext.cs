using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace TheGymApp.Data
{
    public class GymAppContext : DbContext
    {
        public DbContextOptions<GymAppContext> Options { get; }

        public GymAppContext(DbContextOptions<GymAppContext> options) : base(options) => Options = options;

        public DbSet<ZSysUser> Zsysuser { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<UserMembership> UserMemberships { get; set; }

        

    }
}
