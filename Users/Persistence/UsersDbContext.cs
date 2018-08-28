using Microsoft.EntityFrameworkCore;
using System;
using Users.Core.Models;

namespace Users.Persistence
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Gender)
                .HasDefaultValue("M");

            modelBuilder.Entity<UserInterest>()
                .HasKey(ui => new { ui.UserId, ui.InterestId });

            modelBuilder.Entity<Interest>()
                .HasData(
                    new { Id = 1, Name = "IT" },
                    new { Id = 2, Name = "Sports" },
                    new { Id = 3, Name = "Animals" },
                    new { Id = 4, Name = "Food" },
                    new { Id = 5, Name = "Art" },
                    new { Id = 6, Name = "Books" },
                    new { Id = 7, Name = "Cars" }
                );

            modelBuilder.Entity<User>()
                .HasData(
                    new { Id = 1, FullName = "John Smith", Email = "john.smith@gmail.com", ContactPhone = "076485765", ContactAddress = "78 Cedar St. Burke, VA 22015", RegistrationDate = DateTime.Now.AddDays(-10), Gender = 'M' },
                    new { Id = 2, FullName = "Elidia Lowrey", Email = "elidia.lowrey@gmail.com", ContactPhone = "054346876", ContactAddress = "920 Thorne Avenue Elk River, MN 55330", RegistrationDate = DateTime.Now.AddDays(-10), Gender = 'F' },
                    new { Id = 3, FullName = "Linwood Bartz", Email = "linwood.bartz@gmail.com", ContactPhone = "023678398", ContactAddress = "9544 White St. Glen Burnie, MD 21060", RegistrationDate = DateTime.Now.AddDays(-8), Gender = 'M' },
                    new { Id = 4, FullName = "Reva Kunkel", Email = "reva.kunkel@gmail.com", ContactPhone = "0745678765", ContactAddress = "493 Bay Meadows St. Evans, GA 30809", RegistrationDate = DateTime.Now.AddDays(-6), Gender = 'F' },
                    new { Id = 5, FullName = "Marna Lampman", Email = "marna.lampman@gmail.com", ContactPhone = "098543234", ContactAddress = "7827 Miller Street Bedford, OH 44146", RegistrationDate = DateTime.Now.AddDays(-3), Gender = 'F' },
                    new { Id = 6, FullName = "Marcos Tittle", Email = "marcos.tittle@gmail.com", ContactPhone = "087098565", ContactAddress = "8328 Grandrose St. Crystal Lake, IL 60014", RegistrationDate = DateTime.Now.AddDays(-3), Gender = 'M' },
                    new { Id = 7, FullName = "Mia Smits", Email = "mia.smits@gmail.com", ContactPhone = "088654456", ContactAddress = "63 Fawn St. Wantagh, NY 11793", RegistrationDate = DateTime.Now, Gender = 'F' }
                );

            modelBuilder.Entity<UserInterest>()
                .HasData(
                    new { UserId = 1, InterestId = 1 },
                    new { UserId = 1, InterestId = 2 },
                    new { UserId = 1, InterestId = 7 },
                    new { UserId = 2, InterestId = 1 },
                    new { UserId = 3, InterestId = 1 }
                );

        }
    }
}
