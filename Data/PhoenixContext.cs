#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models;

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

        public DbSet<Phoenix.Models.DomAddress> DomAddress { get; set; }

        public DbSet<Phoenix.Models.DomElectroAddress> DomElectroAddress { get; set; }

        public DbSet<Phoenix.Models.DomPersonType> DomPersonType { get; set; }

        public DbSet<Phoenix.Models.DomPublicPlace> DomPublicPlace { get; set; }
    }
}
