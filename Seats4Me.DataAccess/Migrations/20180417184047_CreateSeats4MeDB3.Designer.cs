﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Seats4Me.DataAccess.Context;
using System;

namespace Seats4Me.DataAccess.Migrations
{
    [DbContext(typeof(Seats4MeContext))]
    [Migration("20180417184047_CreateSeats4MeDB3")]
    partial class CreateSeats4MeDB3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Seats4Me.Model.Result.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ScheduleDate");

                    b.Property<int?>("ShowId");

                    b.HasKey("ScheduleId");

                    b.HasIndex("ShowId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Seats4Me.Model.Result.Show", b =>
                {
                    b.Property<int>("ShowId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<TimeSpan>("Duration");

                    b.Property<decimal>("Price");

                    b.Property<string>("SubTitle");

                    b.Property<string>("Title");

                    b.HasKey("ShowId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("Seats4Me.Model.Result.Schedule", b =>
                {
                    b.HasOne("Seats4Me.Model.Result.Show", "Show")
                        .WithMany("Schedule")
                        .HasForeignKey("ShowId");
                });
#pragma warning restore 612, 618
        }
    }
}
