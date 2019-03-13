﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rowa.repository;

namespace rowa.repository.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190313002444_CorrectTableName")]
    partial class CorrectTableName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("rowa.repository.Entites.PageVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IpAddress");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.Property<int>("VisitCount");

                    b.HasKey("Id");

                    b.ToTable("PageVisit");
                });
#pragma warning restore 612, 618
        }
    }
}
