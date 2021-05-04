using Microsoft.EntityFrameworkCore;
using S3Eksamen.Models;
using System;

namespace S3Eksamen.Model
{

    // Kommandoer som du skal bruge når du skal lave databasen
    // add-migration DatabaseNavn
    // update-database –verbose

    // Du skal også bruge den her når du vil ændre i databasen fra model
    // update-database –verbose
    public class LoginContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@$"Server={Environment.MachineName};Database=S3-Eksamen;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}