﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCO.PaymentService.EntityFramework.Persistence;

#nullable disable

namespace SCO.PaymentService.EntityFramework.Migrations
{
    [DbContext(typeof(SCOPaymentContext))]
    partial class SCOPaymentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SCO.PaymentService.Domain.Enteties.MethodOfPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DiscountRule")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MOPs");
                });

            modelBuilder.Entity("SCO.PaymentService.Domain.Enteties.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("MethodOfPaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PaymentDataTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MethodOfPaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("SCO.PaymentService.Domain.Enteties.Payment", b =>
                {
                    b.HasOne("SCO.PaymentService.Domain.Enteties.MethodOfPayment", "MethodOfPayment")
                        .WithMany()
                        .HasForeignKey("MethodOfPaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MethodOfPayment");
                });
#pragma warning restore 612, 618
        }
    }
}
