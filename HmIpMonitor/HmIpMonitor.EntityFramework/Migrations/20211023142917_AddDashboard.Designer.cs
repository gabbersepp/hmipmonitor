﻿// <auto-generated />
using HmIpMonitor.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HmIpMonitor.EntityFramework.Migrations
{
    [DbContext(typeof(HmIpMonitorContext))]
    [Migration("20211023142917_AddDashboard")]
    partial class AddDashboard
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("HmIpMonitor.EntityFramework.Models.CcuDataPoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("DeviceParameterId")
                        .HasColumnType("bigint");

                    b.Property<double>("Quality")
                        .HasColumnType("double precision");

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("DeviceParameterId");

                    b.ToTable("DataPoint");
                });

            modelBuilder.Entity("HmIpMonitor.EntityFramework.Models.Dashboard", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Dashboard");
                });

            modelBuilder.Entity("HmIpMonitor.EntityFramework.Models.DashboardDeviceParameter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("DashboardId")
                        .HasColumnType("bigint");

                    b.Property<long>("DeviceParameterId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DashboardId");

                    b.HasIndex("DeviceParameterId");

                    b.ToTable("DashboardDeviceParameter");
                });

            modelBuilder.Entity("HmIpMonitor.EntityFramework.Models.DeviceParameter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Channel")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("DeviceId")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Parameter")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<double>("ValueErrorThreshold")
                        .HasColumnType("double precision");

                    b.Property<bool>("ValueThresholdDirectionRight")
                        .HasColumnType("boolean");

                    b.Property<double>("ValueWarnThreshold")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("DeviceParameter");
                });

            modelBuilder.Entity("HmIpMonitor.EntityFramework.Models.HmIpDevice", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("HmIpDevice");
                });

            modelBuilder.Entity("HmIpMonitor.EntityFramework.Models.CcuDataPoint", b =>
                {
                    b.HasOne("HmIpMonitor.EntityFramework.Models.DeviceParameter", "DeviceParameter")
                        .WithMany("DataPoints")
                        .HasForeignKey("DeviceParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceParameter");
                });

            modelBuilder.Entity("HmIpMonitor.EntityFramework.Models.DashboardDeviceParameter", b =>
                {
                    b.HasOne("HmIpMonitor.EntityFramework.Models.Dashboard", "Dashboard")
                        .WithMany("DashboardDeviceParameters")
                        .HasForeignKey("DashboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HmIpMonitor.EntityFramework.Models.DeviceParameter", "DeviceParameter")
                        .WithMany()
                        .HasForeignKey("DeviceParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dashboard");

                    b.Navigation("DeviceParameter");
                });

            modelBuilder.Entity("HmIpMonitor.EntityFramework.Models.DeviceParameter", b =>
                {
                    b.HasOne("HmIpMonitor.EntityFramework.Models.HmIpDevice", "Device")
                        .WithMany("DeviceParameter")
                        .HasForeignKey("DeviceId");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("HmIpMonitor.EntityFramework.Models.Dashboard", b =>
                {
                    b.Navigation("DashboardDeviceParameters");
                });

            modelBuilder.Entity("HmIpMonitor.EntityFramework.Models.DeviceParameter", b =>
                {
                    b.Navigation("DataPoints");
                });

            modelBuilder.Entity("HmIpMonitor.EntityFramework.Models.HmIpDevice", b =>
                {
                    b.Navigation("DeviceParameter");
                });
#pragma warning restore 612, 618
        }
    }
}
