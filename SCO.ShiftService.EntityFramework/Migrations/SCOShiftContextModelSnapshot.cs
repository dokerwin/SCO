﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCO.ShiftService.EntityFramework.Persistence;

#nullable disable

namespace SCO.ShiftService.EntityFramework.Migrations
{
    [DbContext(typeof(SCOShiftContext))]
    partial class SCOShiftContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("SCO.ShiftService.Domain.Entities.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CashierId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FinishedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Shifts");
                });
#pragma warning restore 612, 618
        }
    }
}
