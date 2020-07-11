using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Stopaj_Data.Entity;

namespace Stopaj_Data.Context
{
   public class EntityContext:DbContext
    {
        public EntityContext(IConfiguration iConfig)
        {
            config = iConfig;
        }
        public IConfiguration config { get; set; }


        //modelleri db ye tablo olarak ekliyoruz
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogType> LogTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserFilePath> UserFilePaths { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host= localhost; Port= 5432; User Id= postgres; Password = integrall; Database=stopaj");
        }

        //dummy data ile verileri oluşturuyorum 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role() { Id = 1, Name = "Dealer", CreatedDate = DateTime.Now, CreatedBy = 2 },
                new Role() { Id = 2, Name = "CallCenterAdmin", CreatedDate = DateTime.Now, CreatedBy = 2 },
                new Role() { Id = 3, Name = "SporToto", CreatedDate = DateTime.Now, CreatedBy = 2 },
                new Role() { Id = 4, Name = "CallCenter", CreatedDate = DateTime.Now, CreatedBy = 2 }
                );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    DealerId = 11111,
                    Password = "013456",
                    FullName = "test1",
                    DealerName = "iddaa bayisi",
                    Address = "test sk",
                    City = "İstanbul",
                    Email = "test@gmail.com",
                    Phone = "5552223333",
                    IsActive = true,
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = 1,
                    RoleId = 1
                },
                new User()
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    Password = "013456",
                    FullName = "Çağrı merkezi admin",
                    Address = "test sk",
                    City = "İstanbul",
                    Phone = "5558883333",
                    IsActive = true,
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = 1,
                    RoleId = 2
                },
                new User()
                {
                    Id = 3,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    DealerId = 3,
                    Password = "013456",
                    FullName = "SporToto",
                    DealerName = "SporToto ekranı",
                    Address = "test sk",
                    City = "İstanbul",
                    Email = "test@gmail.com",
                    Phone = "5552223333",
                    IsActive = true,
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = 1,
                    RoleId = 3
                }
                );
            modelBuilder.Entity<LogType>().HasData(
                new LogType()
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    Name = "Login"
                },
                new LogType()
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    Name = "SendMail"
                },
                new LogType()
                {
                    Id = 3,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    Name = "SendSMS"
                },
                new LogType()
                {
                    Id = 4,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    Name = "DownloadPDF"
                },
                new LogType()
                {
                    Id = 5,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    Name = "ChangePhone"
                },
                new LogType()
                {
                    Id = 6,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    Name = "Error"
                }

                );
        }

    }
}
