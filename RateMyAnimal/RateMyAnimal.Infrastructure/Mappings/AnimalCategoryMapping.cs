using RateMyAnimal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RateMyAnimal.Infrastructure.Mappings
{
    public class AnimalCategoryMapping : IEntityTypeConfiguration<AnimalCategory>
    {
        public void Configure(EntityTypeBuilder<AnimalCategory> builder)
        {
            builder.ToTable("animal_category");

            builder.HasKey(x => new { x.AnimalId, x.CategoryId });

            builder.Property(x => x.AnimalId)
                .HasColumnName("animal_id")
                .HasColumnType("int");

            builder.Property(x => x.CategoryId)
                .HasColumnName("category_id")
                .HasColumnType("int");

            builder.HasOne<Animal>(x => x.Animal)
                .WithMany(c => c.AnimalCategories)
                .HasForeignKey(x => x.AnimalId);

            builder.HasOne<Category>(x => x.Category)
                .WithMany(c => c.AnimalCategories)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
