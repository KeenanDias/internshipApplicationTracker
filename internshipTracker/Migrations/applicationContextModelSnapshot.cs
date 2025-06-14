﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using internshipTracker;

#nullable disable

namespace internshipTracker.Migrations
{
    [DbContext(typeof(applicationContext))]
    partial class applicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("internshipTracker.application", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("DateApplied")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InternshipStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("applications");

                    b.HasData(
                        new
                        {
                            id = 1,
                            DateApplied = new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InternshipStartDate = new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrganizationName = "test1",
                            Status = "Applied"
                        },
                        new
                        {
                            id = 2,
                            DateApplied = new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InternshipStartDate = new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrganizationName = "test2",
                            Status = "Applied"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
