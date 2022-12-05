using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSharpLab4.Models;

namespace CSharpLab4.Data
{
    public class UserContext : DbContext
    {
        public UserContext (DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Team>()
                .ToTable(nameof(Teams))
                .HasMany(c => c.Players)
                .WithMany(i => i.Teams);
            modelBuilder.Entity<Player>().ToTable(nameof(Players));
            modelBuilder.Entity<Coach>().ToTable(nameof(Coachs));
        }
    }
}
