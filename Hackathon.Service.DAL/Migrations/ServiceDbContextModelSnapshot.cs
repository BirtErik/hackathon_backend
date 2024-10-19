﻿// <auto-generated />
using System;
using Hackathon.Service.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hackathon.Service.DAL.Migrations
{
    [DbContext(typeof(ServiceDbContext))]
    partial class ServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("hackathon")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Hackathon.Service.DAL.Entities.ContractEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<double>("Bills")
                        .HasColumnType("double precision")
                        .HasColumnName("bills");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<double>("Deposit")
                        .HasColumnType("double precision")
                        .HasColumnName("deposit");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Oib")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("oib");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("place");

                    b.Property<string>("PostNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("post_number");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<double>("Vat")
                        .HasColumnType("double precision")
                        .HasColumnName("vat");

                    b.Property<string>("VenueAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("venue_address");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uuid")
                        .HasColumnName("venue_id");

                    b.Property<string>("VenueName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("venue_name");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Contracts", "hackathon");
                });

            modelBuilder.Entity("Hackathon.Service.DAL.Entities.ReservationRequestEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("bank_name");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("Iban")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("iban");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Oib")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("oib");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("purpose");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street_address");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uuid")
                        .HasColumnName("venue_id");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.HasIndex("VenueId");

                    b.ToTable("ReservationRequests", "hackathon");
                });

            modelBuilder.Entity("Hackathon.Service.DAL.Entities.TenantEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Tenants", "hackathon");
                });

            modelBuilder.Entity("Hackathon.Service.DAL.Entities.VenueEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsRentable")
                        .HasColumnType("boolean")
                        .HasColumnName("is_rentable");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenantId");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Venues", "hackathon");
                });

            modelBuilder.Entity("Hackathon.Service.DAL.Entities.VenueReportEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Damage")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("damage");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<DateTimeOffset>("InspectionDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("inspection_date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Oib")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("oib");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("place");

                    b.Property<string>("PostNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("post_number");

                    b.Property<string>("Problems")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("problems");

                    b.Property<string>("StateAfterUsage")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state_after_usage");

                    b.Property<string>("StateBeforeUsage")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state_before_usage");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uuid")
                        .HasColumnName("venue_id");

                    b.Property<string>("VenueName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("venue_name");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("VenueReports", "hackathon");
                });

            modelBuilder.Entity("Hackathon.Service.DAL.Entities.ContractEntity", b =>
                {
                    b.HasOne("Hackathon.Service.DAL.Entities.VenueEntity", null)
                        .WithMany("Contracts")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hackathon.Service.DAL.Entities.ReservationRequestEntity", b =>
                {
                    b.HasOne("Hackathon.Service.DAL.Entities.TenantEntity", null)
                        .WithMany("ReservationRequests")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Hackathon.Service.DAL.Entities.VenueEntity", null)
                        .WithMany("ReservationRequests")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hackathon.Service.DAL.Entities.VenueEntity", b =>
                {
                    b.HasOne("Hackathon.Service.DAL.Entities.TenantEntity", null)
                        .WithMany("Venues")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hackathon.Service.DAL.Entities.VenueReportEntity", b =>
                {
                    b.HasOne("Hackathon.Service.DAL.Entities.VenueEntity", null)
                        .WithMany("VenueReports")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hackathon.Service.DAL.Entities.TenantEntity", b =>
                {
                    b.Navigation("ReservationRequests");

                    b.Navigation("Venues");
                });

            modelBuilder.Entity("Hackathon.Service.DAL.Entities.VenueEntity", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("ReservationRequests");

                    b.Navigation("VenueReports");
                });
#pragma warning restore 612, 618
        }
    }
}
