﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodosWebAPI.Persistance;

namespace TodosWebAPI.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20201121141727_SeedInitialData")]
    partial class SeedInitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("TodosWebAPI.Models.Todo", b =>
                {
                    b.Property<int>("TodoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("TodoID");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            TodoID = 1,
                            IsCompleted = false,
                            Title = "diam. Aliquam id tortor eget ante aliquet commodo non",
                            UserID = 7
                        },
                        new
                        {
                            TodoID = 2,
                            IsCompleted = true,
                            Title = "ornare, leo ac imperdiet malesuada, nisl quam dapibus",
                            UserID = 4
                        },
                        new
                        {
                            TodoID = 3,
                            IsCompleted = false,
                            Title = "eget ante aliquet commodo non a nulla.",
                            UserID = 6
                        },
                        new
                        {
                            TodoID = 4,
                            IsCompleted = true,
                            Title = "Nulla nec lacus nibh. Quisque bibendum",
                            UserID = 7
                        },
                        new
                        {
                            TodoID = 5,
                            IsCompleted = true,
                            Title = "potenti.Proin commodo felis tempor, maximus sem",
                            UserID = 9
                        },
                        new
                        {
                            TodoID = 6,
                            IsCompleted = false,
                            Title = "tortor quis bibendum blandit. Sed",
                            UserID = 8
                        },
                        new
                        {
                            TodoID = 7,
                            IsCompleted = false,
                            Title = "neque vulputate at. Aliquam luctus dictum",
                            UserID = 7
                        },
                        new
                        {
                            TodoID = 8,
                            IsCompleted = true,
                            Title = "et, ultricies ipsum. Proin rhoncus congue nisi, eu interdum",
                            UserID = 3
                        },
                        new
                        {
                            TodoID = 9,
                            IsCompleted = false,
                            Title = "dictum enim quis pharetra consequat. Sed tempus",
                            UserID = 1
                        },
                        new
                        {
                            TodoID = 10,
                            IsCompleted = false,
                            Title = "sollicitudin lacus ac ultricies viverra.",
                            UserID = 5
                        },
                        new
                        {
                            TodoID = 11,
                            IsCompleted = false,
                            Title = "eu neque condimentum, eleifend mollis",
                            UserID = 1
                        },
                        new
                        {
                            TodoID = 12,
                            IsCompleted = true,
                            Title = "dapibus lectus, venenatis congue urna. Praesent egestas",
                            UserID = 3
                        },
                        new
                        {
                            TodoID = 13,
                            IsCompleted = false,
                            Title = "maximus urna, at sagittis odio. Ut auctor urna ac",
                            UserID = 1
                        },
                        new
                        {
                            TodoID = 14,
                            IsCompleted = false,
                            Title = "a tellus ultrices, consequat dui et,",
                            UserID = 8
                        },
                        new
                        {
                            TodoID = 15,
                            IsCompleted = true,
                            Title = "libero vitae aliquet. Nulla eu",
                            UserID = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
