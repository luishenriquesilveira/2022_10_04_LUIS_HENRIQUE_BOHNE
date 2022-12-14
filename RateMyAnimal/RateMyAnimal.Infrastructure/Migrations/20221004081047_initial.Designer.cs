// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RateMyAnimal.Infrastructure.Context;

#nullable disable

namespace RateMyAnimal.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221004081047_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RateMyAnimal.Domain.Entities.Animal", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("image");

                    b.HasKey("Id");

                    b.ToTable("animal", (string)null);
                });

            modelBuilder.Entity("RateMyAnimal.Domain.Entities.AnimalCategory", b =>
                {
                    b.Property<int>("AnimalId")
                        .HasColumnType("int")
                        .HasColumnName("animal_id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.HasKey("AnimalId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("animal_category", (string)null);
                });

            modelBuilder.Entity("RateMyAnimal.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("description");

                    b.HasKey("Id");

                    b.ToTable("category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "cat"
                        },
                        new
                        {
                            Id = 2,
                            Description = "dog"
                        },
                        new
                        {
                            Id = 3,
                            Description = "cute"
                        });
                });

            modelBuilder.Entity("RateMyAnimal.Domain.Entities.AnimalCategory", b =>
                {
                    b.HasOne("RateMyAnimal.Domain.Entities.Animal", "Animal")
                        .WithMany("AnimalCategories")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RateMyAnimal.Domain.Entities.Category", "Category")
                        .WithMany("AnimalCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RateMyAnimal.Domain.Entities.Animal", b =>
                {
                    b.Navigation("AnimalCategories");
                });

            modelBuilder.Entity("RateMyAnimal.Domain.Entities.Category", b =>
                {
                    b.Navigation("AnimalCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
