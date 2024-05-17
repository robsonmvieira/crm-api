using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DE = crm.Project.Domain.domain.entities;

namespace crm.Project.Infra.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<DE.Project>
    {
        public void Configure(EntityTypeBuilder<DE.Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OwnerId).IsRequired();
            builder.Property(x => x.ProjectName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.Deadline).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.Priority).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }

}