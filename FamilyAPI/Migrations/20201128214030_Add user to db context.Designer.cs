﻿// <auto-generated />
using System;
using FamilyAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FamilyAPI.Migrations
{
    [DbContext(typeof(FamilyApiContext))]
    [Migration("20201128214030_Add user to db context")]
    partial class Addusertodbcontext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("FamilyAPI.Models.Authentication.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(32);

                    b.Property<int>("Permissions")
                        .HasColumnType("INTEGER");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FamilyAPI.Models.Families.Adult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EyeColor")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FamilyHouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FamilyStreetName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FamilyHouseNumber", "FamilyStreetName");

                    b.ToTable("Adults");
                });

            modelBuilder.Entity("FamilyAPI.Models.Families.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EyeColor")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FamilyHouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FamilyStreetName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FamilyHouseNumber", "FamilyStreetName");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("FamilyAPI.Models.Families.ChildInterest", b =>
                {
                    b.Property<int>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InterestId")
                        .HasColumnType("TEXT");

                    b.HasKey("ChildId", "InterestId");

                    b.HasIndex("InterestId");

                    b.ToTable("ChildInterest");
                });

            modelBuilder.Entity("FamilyAPI.Models.Families.Family", b =>
                {
                    b.Property<int>("HouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StreetName")
                        .HasColumnType("TEXT");

                    b.HasKey("HouseNumber", "StreetName");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("FamilyAPI.Models.Families.Interest", b =>
                {
                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Type");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("FamilyAPI.Models.Families.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FamilyHouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FamilyStreetName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("FamilyHouseNumber", "FamilyStreetName");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("FamilyAPI.Models.Families.Adult", b =>
                {
                    b.HasOne("FamilyAPI.Models.Families.Family", null)
                        .WithMany("Adults")
                        .HasForeignKey("FamilyHouseNumber", "FamilyStreetName");
                });

            modelBuilder.Entity("FamilyAPI.Models.Families.Child", b =>
                {
                    b.HasOne("FamilyAPI.Models.Families.Family", null)
                        .WithMany("Children")
                        .HasForeignKey("FamilyHouseNumber", "FamilyStreetName");
                });

            modelBuilder.Entity("FamilyAPI.Models.Families.ChildInterest", b =>
                {
                    b.HasOne("FamilyAPI.Models.Families.Child", "Child")
                        .WithMany("ChildInterests")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FamilyAPI.Models.Families.Interest", "Interest")
                        .WithMany("ChildInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FamilyAPI.Models.Families.Pet", b =>
                {
                    b.HasOne("FamilyAPI.Models.Families.Child", null)
                        .WithMany("Pets")
                        .HasForeignKey("ChildId");

                    b.HasOne("FamilyAPI.Models.Families.Family", null)
                        .WithMany("Pets")
                        .HasForeignKey("FamilyHouseNumber", "FamilyStreetName");
                });
#pragma warning restore 612, 618
        }
    }
}
