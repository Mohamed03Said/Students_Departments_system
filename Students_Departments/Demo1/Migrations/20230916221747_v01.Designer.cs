﻿// <auto-generated />
using System;
using Demo1.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demo1.Migrations
{
    [DbContext(typeof(CollegeContext))]
    [Migration("20230916221747_v01")]
    partial class v01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Demo1.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("DeptId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Demo1.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("DeptNo")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("DeptNo");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Demo1.Models.Student", b =>
                {
                    b.HasOne("Demo1.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DeptNo")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Demo1.Models.Department", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
