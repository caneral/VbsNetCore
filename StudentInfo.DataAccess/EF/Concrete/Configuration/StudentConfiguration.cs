using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentInfo.Entity.Entity;

namespace StudentInfo.DataAccess.EF.Concrete.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(s => s.TCNumber);
            builder.Property(s => s.TCNumber).HasMaxLength(11).IsRequired();
            builder.Property(s => s.Name).HasMaxLength(50).IsRequired();
            builder.Property(s => s.Surname).HasMaxLength(50).IsRequired();
            builder.Property(s => s.Number).HasMaxLength(11).IsRequired();

            builder.HasOne(s => s.ParentFK).WithMany(s => s.Students).HasForeignKey(s => s.ParentId);
            builder.HasMany(s => s.StudentTeachers).WithOne(s => s.StudentFK).HasForeignKey(s => s.StudentId);
            builder.HasMany(s => s.Meets).WithOne(s => s.StudentFK).HasForeignKey(s => s.StudentId);
            builder.HasOne(s => s.ClassFK).WithMany(s => s.Students).HasForeignKey(s => s.ClassId);
        }
    }
}
