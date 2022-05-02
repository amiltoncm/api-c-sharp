using Microsoft.EntityFrameworkCore;

namespace Phoenix.Data
{
    public class PhoenixContext : DbContext
    {
        public PhoenixContext (DbContextOptions<PhoenixContext> options)
            : base(options)
        {
        }

        public DbSet<Phoenix.Models.UsersProfile> UsersProfile { get; set; }

        public DbSet<Phoenix.Models.User> User { get; set; }

        public DbSet<Phoenix.Models.Account> Account { get; set; }

        public DbSet<Phoenix.Models.Bank> Bank { get; set; }

        public DbSet<Phoenix.Models.Country> Country { get; set; }

        public DbSet<Phoenix.Models.Regime> Regime { get; set; }

        public DbSet<Phoenix.Models.State> State { get; set; }

        public DbSet<Phoenix.Models.AddressType> AddressType { get; set; }

        public DbSet<Phoenix.Models.ElectroAddressType> ElectroAddressType { get; set; }

        public DbSet<Phoenix.Models.PersonType> PersonType { get; set; }

        public DbSet<Phoenix.Models.PublicPlace> PublicPlace { get; set; }

        public DbSet<Phoenix.Models.City> City { get; set; }

        public DbSet<Phoenix.Models.Company> Company { get; set; }
    }
}
