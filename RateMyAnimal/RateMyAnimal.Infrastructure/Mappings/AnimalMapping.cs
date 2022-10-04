using RateMyAnimal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RateMyAnimal.Infrastructure.Mappings
{
    public class AnimalMapping : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("animal");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Image)
                .HasColumnName("image")
                .HasColumnType("varbinary(max)")
                .IsRequired();

            builder.Property(x => x.Date)
                .HasColumnName("date")
                .HasColumnType("datetime")
                .IsRequired();


        }
    }
}
