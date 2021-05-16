using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentInfo.Entity.Entity;

namespace StudentInfo.DataAccess.EF.Concrete.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(t => t.TCNumber);
            builder.Property(t => t.TCNumber).HasMaxLength(11).IsRequired();
            builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Surname).HasMaxLength(50).IsRequired();

            builder.HasMany(t => t.StudentTeachers).WithOne(t => t.TeacherFK).HasForeignKey(t => t.TeacherId);
            builder.HasMany(t => t.Meets).WithOne(t => t.TeacherFK).HasForeignKey(t => t.TeacherId);
        }
    }
}
