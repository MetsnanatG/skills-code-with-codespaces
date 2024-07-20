using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Data
{


    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<EVoucher> EVouchers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Simcard> SimCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed EVouchers}}
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<EVoucher>().HasData(new EVoucher
                {
                    Id = i,
                    Code = $"1000{i}",
                    ExpiryDate = DateTime.Now.AddDays(30)
                });
            }

            // Seed Devices
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<Device>().HasData(new Device
                {
                    Id = i,
                    Name = $"D00{i}",
                    Model = $"M00{i}"

                    // Set other properties for Device
                });
            }

            // Seed SimCards
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<Simcard>().HasData(new Simcard
                {
                    Id = i,
                    // generate other properties for Simcard
                    ICCID = $"ICCID00{i}",
                    IMSI = $"IMSI00{i}"
                });
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
