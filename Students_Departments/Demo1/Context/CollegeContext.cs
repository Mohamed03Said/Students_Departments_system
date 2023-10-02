using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Context
{
    public class CollegeContext:DbContext
    {
        public DbSet<Student> Students { set; get; }
        public DbSet<Department> Departments { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .;Database = mvc_iti ; Trusted_Connection = True ;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Students)
                .WithOne(s => s.Department)
                .HasForeignKey(s => s.DeptNo)
                .OnDelete(DeleteBehavior.SetNull); // Set DeptNo to null on delete
        }
    }
}
