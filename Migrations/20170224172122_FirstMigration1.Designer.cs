﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using craigslist.Models;

namespace craigslist.Migrations
{
    [DbContext(typeof(CraigsListDBContext))]
    [Migration("20170224172122_FirstMigration1")]
    partial class FirstMigration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("craigslist.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_At");

                    b.Property<string>("Email");

                    b.Property<string>("First_Name");

                    b.Property<string>("Last_Name");

                    b.Property<string>("Password");

                    b.Property<DateTime>("Updated_At");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
        }
    }
}
