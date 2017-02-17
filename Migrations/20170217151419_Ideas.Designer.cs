using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using idea.Models;

namespace clogin.Migrations
{
    [DbContext(typeof(IdeasDBContext))]
    [Migration("20170217151419_Ideas")]
    partial class Ideas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("idea.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_At");

                    b.Property<string>("Email");

                    b.Property<string>("First_Name");

                    b.Property<string>("Last_Name");

                    b.Property<string>("Password");

                    b.Property<DateTime>("Updated_At");

                    b.Property<int>("Wallet");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
        }
    }
}
