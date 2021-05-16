using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentInfo.Entity.Entity;

namespace StudentInfo.DataAccess.EF.Concrete.Configuration
{
    public class MeetConfiguration : IEntityTypeConfiguration<Meet>
    {
        public void Configure(EntityTypeBuilder<Meet> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.MeetDate).IsRequired();
        }
    }
}
