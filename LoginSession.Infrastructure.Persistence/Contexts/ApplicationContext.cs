using LoginSession.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSession.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(150)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Phone)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}