using Microsoft.EntityFrameworkCore;
using NosTrinks.Context.Mapping;
using NosTrinks.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosTrinks.Context.ContextApi
{
    public class NosTrinksWebApiContext : DbContext
    {
        public NosTrinksWebApiContext(DbContextOptions<NosTrinksWebApiContext> options)
            : base(options)
        {        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserService> UserServices { get; set; }
        public DbSet<UserAgenda> UserAgendas { get; set; }
        public DbSet<UserDisponibility> UserDisponibilities { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());

            base.OnModelCreating(modelBuilder);

            //seed Method for Roles
            modelBuilder.Entity<Role>(opt => {
                opt.HasData(
                        new {Id = 1, Description = "Cabeleireiro"},
                        new {Id = 2, Description = "Manicure"},
                        new {Id = 3, Description = "Barbeiro"}
                    );
            });

            //seed Method for default admin User
            modelBuilder.Entity<User>(opt => {
                opt.HasData
                (
                    new {
                        Id =1,
                        Email = "admin@admin.com",
                        Name = "Admin",
                        Password = "adminSeed",
                        IsActive = true,
                        IsAdmin = true
                    }
                );
            });

            modelBuilder.Entity<Service>(opt => {
                opt.HasData
                (
                    new
                    {
                        Id = 1,
                        Description = "Corte Masculino"
                    },
                    new
                    {
                        Id = 2,
                        Description = "Corte feminino"
                    }
                );
            });
        }
    }
}
