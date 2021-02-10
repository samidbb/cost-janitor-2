﻿// <auto-generated />
using System;
using CostJanitor.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CostJanitor.Infrastructure.EntityFramework.Migrations
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

            modelBuilder.Entity("CostJanitor.Domain.Aggregates.ReportItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ReportItem");
                });

            modelBuilder.Entity("CostJanitor.Domain.Aggregates.ReportItem", b =>
                {
                    b.OwnsMany("CostJanitor.Domain.ValueObjects.CostItem", "CostItems", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .UseIdentityByDefaultColumn();

                            b1.Property<string>("CapabilityIdentifier")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Label")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<Guid>("OwnerId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("Id");

                            b1.HasIndex("OwnerId");

                            b1.ToTable("CostItems");

                            b1.WithOwner()
                                .HasForeignKey("OwnerId");
                        });

                    b.Navigation("CostItems");
                });
#pragma warning restore 612, 618
        }
    }
}
