﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Viapos.LicenceManager.API.Data;

#nullable disable

namespace Viapos.LicenceManager.API.Migrations
{
    [DbContext(typeof(LicenseContext))]
    partial class LicenseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Viapos.LicenceManager.LicenceInformations.Tables.License", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("LicenseCount")
                        .HasColumnType("int");

                    b.Property<int>("LicenseType")
                        .HasColumnType("int");

                    b.Property<int>("OnlineLicense")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("Viapos.LicenceManager.LicenceInformations.Tables.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LicenseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ModuleTypeEnum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LicenseId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Viapos.LicenceManager.LicenceInformations.Tables.SystemInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("InfoType")
                        .HasColumnType("int");

                    b.Property<Guid>("LicenseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LicenseId");

                    b.ToTable("SystemInfos");
                });

            modelBuilder.Entity("Viapos.LicenceManager.LicenceInformations.Tables.Module", b =>
                {
                    b.HasOne("Viapos.LicenceManager.LicenceInformations.Tables.License", null)
                        .WithMany("Modules")
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Viapos.LicenceManager.LicenceInformations.Tables.SystemInfo", b =>
                {
                    b.HasOne("Viapos.LicenceManager.LicenceInformations.Tables.License", null)
                        .WithMany("SystemInfos")
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Viapos.LicenceManager.LicenceInformations.Tables.License", b =>
                {
                    b.Navigation("Modules");

                    b.Navigation("SystemInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
