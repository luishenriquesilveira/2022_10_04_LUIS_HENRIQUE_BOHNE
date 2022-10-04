using RateMyAnimal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RateMyAnimal.Infrastructure.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(25)")
                .IsRequired();

            builder.HasData(new Category(1, "cat"));
            builder.HasData(new Category(2, "dog"));
            builder.HasData(new Category(3, "cute"));
        }
    }
}
