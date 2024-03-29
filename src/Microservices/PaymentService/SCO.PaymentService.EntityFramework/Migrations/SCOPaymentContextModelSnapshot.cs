﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("SCO.PaymentService.Domain.Enteties.MethodOfPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("DiscountRule")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MOPs");
                });

            modelBuilder.Entity("SCO.PaymentService.Domain.Enteties.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MethodOfPaymentId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PaymentDataTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

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
