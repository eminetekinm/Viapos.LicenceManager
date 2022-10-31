﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Viapos.LicenceManager.API.Data;

#nullable disable

namespace Viapos.LicenceManager.API.Migrations
{
    [DbContext(typeof(LicenseContext))]
    [Migration("20221031201250_firstMig")]
    partial class firstMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LicenseCount")
                        .HasColumnType("int");

                    b.Property<int>("LicenseType")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("Viapos.LicenceManager.LicenceInformations.Tables.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid?>("LicenseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ModuleTypeEnum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LicenseId");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("Viapos.LicenceManager.LicenceInformations.Tables.SystemInfo", b =>
                {
                    b.Property<int>("InfoType")
                        .HasColumnType("int");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LicenseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InfoType");

                    b.HasIndex("LicenseId");

                    b.ToTable("SystemInfo");
                });

            modelBuilder.Entity("Viapos.LicenceManager.LicenceInformations.Tables.Module", b =>
                {
                    b.HasOne("Viapos.LicenceManager.LicenceInformations.Tables.License", null)
                        .WithMany("Modules")
                        .HasForeignKey("LicenseId");
                });

            modelBuilder.Entity("Viapos.LicenceManager.LicenceInformations.Tables.SystemInfo", b =>
                {
                    b.HasOne("Viapos.LicenceManager.LicenceInformations.Tables.License", null)
                        .WithMany("SystemInfos")
                        .HasForeignKey("LicenseId");
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
