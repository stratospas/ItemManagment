using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagment.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Item> items { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Place> Places { get; set; }

        public string path = @"C:\Users\StandAlone\source\repos\ItemManagment\Management.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Internal_code = "E/B/0000", Description = "Lenovo H/Y i5", Serial_number = "AASSDD8875" },
                new Item { Id = 2, Internal_code = "E/B/0000", Description = "Lenovo H/Y i5", Serial_number = "AASSDD8975" },
                new Item { Id = 3, Internal_code = "E/B/1111", Description = "Lenovo Screen 24\"", Serial_number = "AASSDD2222" },
                new Item { Id = 4, Internal_code = "E/B/1110", Description = "Xiaomi RedMi Note 8", Serial_number = "AASSDD0000" }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, Number = 1 },
                new Department { DepartmentId = 2, Number = 2 },
                new Department { DepartmentId = 3, Number = 3 },
                new Department { DepartmentId = 4, Number = 4 }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person { PersonId = 1, Name = "Στράτος", Lastname = "Πασχαλίδης", DepartmentId = 1 },
                new Person { PersonId = 2, Name = "Αλέξανδρος", Lastname = "Παπαδόπουλος", DepartmentId = 2 }
            );

            modelBuilder.Entity<Place>().HasData(
                new Place { PlaceId = 1, Floor = 14, Number = 47 },
                new Place { PlaceId = 2, Floor = 14, Number = 45 },
                new Place { PlaceId = 3, Floor = 14, Number = 40 }
            );
        }
    }
}
