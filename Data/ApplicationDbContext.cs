using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    Name = "John Doe",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Married = true,
                    Phone = "555-1234",
                    Salary = 50000m
                },
                new Contact
                {
                    Id = 2,
                    Name = "Jane Smith",
                    DateOfBirth = new DateTime(1985, 5, 23),
                    Married = false,
                    Phone = "555-5678",
                    Salary = 60000m
                },
                new Contact
                {
                    Id = 3,
                    Name = "Mark Johnson",
                    DateOfBirth = new DateTime(1975, 11, 15),
                    Married = true,
                    Phone = "555-9876",
                    Salary = 75000m
                },
                new Contact
                {
                    Id = 4,
                    Name = "Emily Brown",
                    DateOfBirth = new DateTime(1992, 3, 8),
                    Married = false,
                    Phone = "555-4321",
                    Salary = 45000m
                },
                new Contact
                {
                    Id = 5,
                    Name = "Michael Wilson",
                    DateOfBirth = new DateTime(1988, 12, 22),
                    Married = true,
                    Phone = "555-8765",
                    Salary = 55000m
                }
            );
        }
    }
}
