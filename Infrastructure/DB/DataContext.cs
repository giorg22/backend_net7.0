using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DB
{
    public class DataContext : IdentityDbContext<User, Role, string>
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString: "Data Source=10.10.10.14;Initial Catalog=Morti;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=DevZepp!@#123AAA;MultipleActiveResultSets=True;TrustServerCertificate=true");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
