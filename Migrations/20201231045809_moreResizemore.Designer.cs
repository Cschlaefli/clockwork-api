﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tephraAPI.Models;

namespace tephraAPI.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20201231045809_moreResizemore")]
    partial class moreResizemore
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("tephraAPI.Models.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Accuracy")
                        .HasColumnType("int");

                    b.Property<string>("Attr")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Augments")
                        .HasColumnType("int");

                    b.Property<string>("Cost")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("DIY")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("longtext");

                    b.Property<int>("Evade")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Notes")
                        .HasMaxLength(5000)
                        .HasColumnType("longtext");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("Reflexive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Requirments")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Resist")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Skill")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<bool>("Stance")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Strike")
                        .HasColumnType("int");

                    b.Property<string>("Subtype")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Wounds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Specialties");
                });
#pragma warning restore 612, 618
        }
    }
}
