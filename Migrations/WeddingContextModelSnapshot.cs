﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeddingPlanner.Models;

namespace WeddingPlanner.Migrations
{
    [DbContext(typeof(WeddingContext))]
    partial class WeddingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WeddingPlanner.Models.Association", b =>
                {
                    b.Property<int>("AssociationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.Property<int>("WeddingId");

                    b.HasKey("AssociationId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeddingId");

                    b.ToTable("Associations");
                });

            modelBuilder.Entity("WeddingPlanner.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.Property<int>("WeddingId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("PlannerUserId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("WedderOne")
                        .IsRequired();

                    b.Property<string>("WedderTwo")
                        .IsRequired();

                    b.Property<string>("WeddingAddress")
                        .IsRequired();

                    b.Property<DateTime>("WeddingDate");

                    b.HasKey("WeddingId");

                    b.HasIndex("PlannerUserId");

                    b.ToTable("Weddings");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Association", b =>
                {
                    b.HasOne("WeddingPlanner.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WeddingPlanner.Models.Wedding", "Wedding")
                        .WithMany()
                        .HasForeignKey("WeddingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.HasOne("WeddingPlanner.Models.User", "Planner")
                        .WithMany()
                        .HasForeignKey("PlannerUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
