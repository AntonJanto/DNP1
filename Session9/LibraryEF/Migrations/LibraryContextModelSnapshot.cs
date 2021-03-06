﻿// <auto-generated />
using System;
using LibraryEF.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LibraryEF.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LibraryEF.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("author_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("bio");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.HasKey("AuthorId")
                        .HasName("pk_authors");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("LibraryEF.Models.Book", b =>
                {
                    b.Property<int>("ISBN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("isbn")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    b.Property<int?>("GenreId")
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("publish_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<int>("TotalPages")
                        .HasColumnType("integer")
                        .HasColumnName("total_pages");

                    b.HasKey("ISBN")
                        .HasName("pk_books");

                    b.HasIndex("AuthorId")
                        .HasDatabaseName("ix_books_author_id");

                    b.HasIndex("GenreId")
                        .HasDatabaseName("ix_books_genre_id");

                    b.ToTable("books");
                });

            modelBuilder.Entity("LibraryEF.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("genre_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("genre_name");

                    b.HasKey("GenreId")
                        .HasName("pk_genres");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("LibraryEF.Models.Book", b =>
                {
                    b.HasOne("LibraryEF.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("fk_books_authors_author_id");

                    b.HasOne("LibraryEF.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .HasConstraintName("fk_books_genres_genre_id");

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
