using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Persistance.Data
{
    public class TaskManagementSystemDbContext(DbContextOptions<TaskManagementSystemDbContext> options):DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedData();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        public DbSet<ErrorLog> ErrorLogs { get; set; }

    }

    static class ModelBuilderExtension
    {
            public static void SeedData(this ModelBuilder modelBuilder)
            {
              
            }
        }

    
}
