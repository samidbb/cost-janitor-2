﻿// <auto-generated />
using System;
using CostJanitor.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CostJanitor.Infrastructure.Migrations
{
    [DbContext(typeof(DomainContext))]
    partial class DomainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CostItemReportItem", b =>
                {
                    b.Property<Guid>("CostItemsId")
                        .HasColumnType("uuid");

                    b.Property<string>("CostItemsLabel")
                        .HasColumnType("text");

                    b.HasKey("CostItemsId", "CostItemsLabel");

                    b.HasIndex("CostItemsLabel");

                    b.ToTable("CostItemReportItem");
                });

            modelBuilder.Entity("CostJanitor.Domain.Aggregates.ReportItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ReportItem");
                });

            modelBuilder.Entity("CostJanitor.Domain.ValueObjects.CostItem", b =>
                {
                    b.Property<string>("Label")
                        .HasColumnType("text");

                    b.Property<string>("CapabilityIdentifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Label");

                    b.ToTable("CostItem");
                });

            modelBuilder.Entity("CostItemReportItem", b =>
                {
                    b.HasOne("CostJanitor.Domain.Aggregates.ReportItem", null)
                        .WithMany()
                        .HasForeignKey("CostItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CostJanitor.Domain.ValueObjects.CostItem", null)
                        .WithMany()
                        .HasForeignKey("CostItemsLabel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
