using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentInfo.Entity.Entity;

namespace StudentInfo.DataAccess.EF.Concrete.Configuration
{
    public class HomeWorkConfiguration : IEntityTypeConfiguration<HomeWork>
    {
        public void Configure(EntityTypeBuilder<HomeWork> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.CourseName).HasMaxLength(50).IsRequired();
            builder.Property(s => s.HomeworkSubject).HasMaxLength(50).IsRequired();
            builder.Property(s => s.HomeworkDesc).HasMaxLength(255).IsRequired();

            builder.HasOne(s => s.ClassFK).WithMany(s => s.HomeWorks).HasForeignKey(s => s.ClassId);
        }
    }
}
