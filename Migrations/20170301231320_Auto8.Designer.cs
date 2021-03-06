﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using craigslist.Models;

namespace craigslist.Migrations
{
    [DbContext(typeof(CraigsListDBContext))]
    [Migration("20170301231320_Auto8")]
    partial class Auto8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("craigslist.Models.Auto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Make")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<string>("Part");

                    b.Property<int>("Price");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Auto");
                });

            modelBuilder.Entity("craigslist.Models.AutoTalk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarId");

                    b.Property<string>("Comment")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("AutoTalk");
                });

            modelBuilder.Entity("craigslist.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("First_Name");

                    b.Property<string>("Last_Name");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
        }
    }
}
