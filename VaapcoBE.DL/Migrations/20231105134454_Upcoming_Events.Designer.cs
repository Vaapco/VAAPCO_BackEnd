﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VaapcoBE.DL;

#nullable disable

namespace VaapcoBE.DL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231105134454_Upcoming_Events")]
    partial class Upcoming_Events
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VaapcoBE.DL.Entities.NewsHeadline", b =>
                {
                    b.Property<int>("HId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HId"), 1L, 1);

                    b.Property<DateTime>("Date_Posted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Headline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeadlineLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HId");

                    b.ToTable("NewsHeadlines");
                });

            modelBuilder.Entity("VaapcoBE.DL.Entities.UpcomingEvent", b =>
                {
                    b.Property<int>("EId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EId"), 1L, 1);

                    b.Property<DateTime>("EventAddDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventTitile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventVenue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EId");

                    b.ToTable("UpcomingEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
