using Microsoft.EntityFrameworkCore;
using StudentForm.Models;

namespace StudentForm.Repositories
{
    public class CollectionContext:DbContext
    {
        public DbSet<Student> Student {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String conn = "Server=localhost;Port=3306;Database=student;User=root;Password=Shiv@1234";
            optionsBuilder.UseMySQL(conn);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.email);
                entity.Property(e => e.isactive);
                entity.Property(e => e.fees);
                entity.Property(e => e.contact_number);
                entity.Property(e => e.address);
                entity.Property(e => e.admission_date);
                entity.Property(e => e.name);
            }
            );
            modelBuilder.Entity<Student>().ToTable("student");
        }
    }
}
