﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sda.EntityFrameworkCore;

namespace Sda.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Sda.Core.Models.HREntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BattleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConcurrencyStamp")
                        .HasColumnType("uuid");

                    b.Property<int>("CurTime")
                        .HasColumnType("integer");

                    b.Property<bool>("IsOver")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("HREntitys", "SDA");
                });
#pragma warning restore 612, 618
        }
    }
}
