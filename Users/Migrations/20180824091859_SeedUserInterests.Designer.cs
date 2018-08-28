﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Users.Persistence;

namespace Users.Migrations
{
    [DbContext(typeof(UsersDbContext))]
    [Migration("20180824091859_SeedUserInterests")]
    partial class SeedUserInterests
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Users.Core.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Interests");

                    b.HasData(
                        new { Id = 1, Name = "IT" },
                        new { Id = 2, Name = "Sports" },
                        new { Id = 3, Name = "Animals" },
                        new { Id = 4, Name = "Food" },
                        new { Id = 5, Name = "Art" },
                        new { Id = 6, Name = "Books" },
                        new { Id = 7, Name = "Cars" }
                    );
                });

            modelBuilder.Entity("Users.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactAddress")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasDefaultValue("M");

                    b.Property<DateTime>("RegistrationDate");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, ContactAddress = "78 Cedar St. Burke, VA 22015", ContactPhone = "076485765", Email = "john.smith@gmail.com", FullName = "John Smith", Gender = "M", RegistrationDate = new DateTime(2018, 8, 14, 11, 18, 57, 440, DateTimeKind.Local) },
                        new { Id = 2, ContactAddress = "920 Thorne Avenue Elk River, MN 55330", ContactPhone = "054346876", Email = "elidia.lowrey@gmail.com", FullName = "Elidia Lowrey", Gender = "F", RegistrationDate = new DateTime(2018, 8, 14, 11, 18, 57, 443, DateTimeKind.Local) },
                        new { Id = 3, ContactAddress = "9544 White St. Glen Burnie, MD 21060", ContactPhone = "023678398", Email = "linwood.bartz@gmail.com", FullName = "Linwood Bartz", Gender = "M", RegistrationDate = new DateTime(2018, 8, 16, 11, 18, 57, 443, DateTimeKind.Local) },
                        new { Id = 4, ContactAddress = "493 Bay Meadows St. Evans, GA 30809", ContactPhone = "0745678765", Email = "reva.kunkel@gmail.com", FullName = "Reva Kunkel", Gender = "F", RegistrationDate = new DateTime(2018, 8, 18, 11, 18, 57, 443, DateTimeKind.Local) },
                        new { Id = 5, ContactAddress = "7827 Miller Street Bedford, OH 44146", ContactPhone = "098543234", Email = "marna.lampman@gmail.com", FullName = "Marna Lampman", Gender = "F", RegistrationDate = new DateTime(2018, 8, 21, 11, 18, 57, 443, DateTimeKind.Local) },
                        new { Id = 6, ContactAddress = "8328 Grandrose St. Crystal Lake, IL 60014", ContactPhone = "087098565", Email = "marcos.tittle@gmail.com", FullName = "Marcos Tittle", Gender = "M", RegistrationDate = new DateTime(2018, 8, 21, 11, 18, 57, 443, DateTimeKind.Local) },
                        new { Id = 7, ContactAddress = "63 Fawn St. Wantagh, NY 11793", ContactPhone = "088654456", Email = "mia.smits@gmail.com", FullName = "Mia Smits", Gender = "F", RegistrationDate = new DateTime(2018, 8, 24, 11, 18, 57, 443, DateTimeKind.Local) }
                    );
                });

            modelBuilder.Entity("Users.Core.Models.UserInterest", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("InterestId");

                    b.HasKey("UserId", "InterestId");

                    b.HasIndex("InterestId");

                    b.ToTable("UserInterests");

                    b.HasData(
                        new { UserId = 1, InterestId = 1 },
                        new { UserId = 1, InterestId = 2 },
                        new { UserId = 1, InterestId = 7 },
                        new { UserId = 2, InterestId = 1 },
                        new { UserId = 3, InterestId = 1 }
                    );
                });

            modelBuilder.Entity("Users.Core.Models.UserInterest", b =>
                {
                    b.HasOne("Users.Core.Models.Interest", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Users.Core.Models.User", "User")
                        .WithMany("Interests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
