﻿// <auto-generated />
using COMP003B.Week7Assignment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace COMP003B.Week7Assignment.Migrations
{
    [DbContext(typeof(MovieCatalogueContext))]
    partial class MovieCatalogueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("COMP003B.Week7Assignment.Models.Actor", b =>
                {
                    b.Property<int>("actorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("actorId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("actorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rolePlayed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("actorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("COMP003B.Week7Assignment.Models.IMDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("actorId")
                        .HasColumnType("int");

                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("actorId");

                    b.HasIndex("movieId");

                    b.ToTable("IMDBs");
                });

            modelBuilder.Entity("COMP003B.Week7Assignment.Models.Movie", b =>
                {
                    b.Property<int>("movieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("movieId"));

                    b.Property<string>("movieTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("yearReleased")
                        .HasColumnType("int");

                    b.HasKey("movieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("COMP003B.Week7Assignment.Models.IMDB", b =>
                {
                    b.HasOne("COMP003B.Week7Assignment.Models.Actor", "Actor")
                        .WithMany("IMDBs")
                        .HasForeignKey("actorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COMP003B.Week7Assignment.Models.Movie", "Movie")
                        .WithMany("IMDBs")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("COMP003B.Week7Assignment.Models.Actor", b =>
                {
                    b.Navigation("IMDBs");
                });

            modelBuilder.Entity("COMP003B.Week7Assignment.Models.Movie", b =>
                {
                    b.Navigation("IMDBs");
                });
#pragma warning restore 612, 618
        }
    }
}
