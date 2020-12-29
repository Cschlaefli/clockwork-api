﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tephraAPI.Models;

namespace tephraAPI.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20201229162441_addName")]
    partial class addName
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

                    b.Property<int>("Acc")
                        .HasColumnType("int");

                    b.Property<int>("Aug")
                        .HasColumnType("int");

                    b.Property<int>("DIY")
                        .HasColumnType("int");

                    b.Property<int>("Def")
                        .HasColumnType("int");

                    b.Property<int>("Eva")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Notes")
                        .HasMaxLength(5000)
                        .HasColumnType("longtext");

                    b.Property<int>("Pri")
                        .HasColumnType("int");

                    b.Property<string>("Requirments")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Skill")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Spd")
                        .HasColumnType("int");

                    b.Property<int>("Stk")
                        .HasColumnType("int");

                    b.Property<int>("Wnd")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Specialties");
                });
#pragma warning restore 612, 618
        }
    }
}
