﻿// <auto-generated />
using System;
using Adapter.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Adapter.Database.Migrations
{
    [DbContext(typeof(FreeJokesContext))]
    [Migration("20201114214731_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Airplane Jokes"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Animal Jokes"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Baby Jokes"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Bar & Drinking Jokes"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Business Jokes"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "College Jokes"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Computer Jokes"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Cross the Road Jokes"
                        },
                        new
                        {
                            Id = 9L,
                            Name = "Dentist Jokes"
                        },
                        new
                        {
                            Id = 10L,
                            Name = "Doctor Jokes"
                        },
                        new
                        {
                            Id = 11L,
                            Name = "Dumb Criminals"
                        },
                        new
                        {
                            Id = 12L,
                            Name = "Elderly Jokes"
                        },
                        new
                        {
                            Id = 13L,
                            Name = "Entertainment Jokes"
                        },
                        new
                        {
                            Id = 14L,
                            Name = "Family Jokes"
                        },
                        new
                        {
                            Id = 15L,
                            Name = "Farmer Jokes"
                        },
                        new
                        {
                            Id = 16L,
                            Name = "Food Jokes"
                        },
                        new
                        {
                            Id = 17L,
                            Name = "Golf Jokes"
                        },
                        new
                        {
                            Id = 18L,
                            Name = "Holiday Jokes"
                        },
                        new
                        {
                            Id = 19L,
                            Name = "Judge Jokes"
                        },
                        new
                        {
                            Id = 20L,
                            Name = "Kid Jokes"
                        },
                        new
                        {
                            Id = 21L,
                            Name = "Knock Knock Jokes"
                        },
                        new
                        {
                            Id = 22L,
                            Name = "Lawyer Jokes"
                        },
                        new
                        {
                            Id = 23L,
                            Name = "Lightbulb Jokes"
                        },
                        new
                        {
                            Id = 24L,
                            Name = "Little Johnny Jokes"
                        },
                        new
                        {
                            Id = 25L,
                            Name = "Love Jokes"
                        },
                        new
                        {
                            Id = 26L,
                            Name = "Marriage Jokes"
                        },
                        new
                        {
                            Id = 27L,
                            Name = "Military Jokes"
                        },
                        new
                        {
                            Id = 28L,
                            Name = "Misc Jokes"
                        },
                        new
                        {
                            Id = 29L,
                            Name = "Money Jokes"
                        },
                        new
                        {
                            Id = 30L,
                            Name = "Musician Jokes"
                        },
                        new
                        {
                            Id = 31L,
                            Name = "National Jokes"
                        },
                        new
                        {
                            Id = 32L,
                            Name = "News Jokes"
                        },
                        new
                        {
                            Id = 33L,
                            Name = "Office Jokes"
                        },
                        new
                        {
                            Id = 34L,
                            Name = "One Liner Jokes"
                        },
                        new
                        {
                            Id = 35L,
                            Name = "Pickup Jokes"
                        },
                        new
                        {
                            Id = 36L,
                            Name = "Police Jokes"
                        },
                        new
                        {
                            Id = 37L,
                            Name = "Political Jokes"
                        },
                        new
                        {
                            Id = 38L,
                            Name = "Pop Culture Jokes"
                        },
                        new
                        {
                            Id = 39L,
                            Name = "Programmer Jokes"
                        },
                        new
                        {
                            Id = 40L,
                            Name = "Puns"
                        },
                        new
                        {
                            Id = 41L,
                            Name = "Relationship Jokes"
                        },
                        new
                        {
                            Id = 42L,
                            Name = "Religious Jokes"
                        },
                        new
                        {
                            Id = 43L,
                            Name = "Salespeople Jokes"
                        },
                        new
                        {
                            Id = 44L,
                            Name = "School Jokes"
                        },
                        new
                        {
                            Id = 45L,
                            Name = "Science Jokes"
                        },
                        new
                        {
                            Id = 46L,
                            Name = "Scifi Jokes"
                        },
                        new
                        {
                            Id = 47L,
                            Name = "Sport Jokes"
                        },
                        new
                        {
                            Id = 48L,
                            Name = "Star Wars Jokes"
                        },
                        new
                        {
                            Id = 49L,
                            Name = "Teacher Jokes"
                        },
                        new
                        {
                            Id = 50L,
                            Name = "Technology Jokes"
                        },
                        new
                        {
                            Id = 51L,
                            Name = "Word Play Jokes"
                        },
                        new
                        {
                            Id = 52L,
                            Name = "Work Jokes"
                        },
                        new
                        {
                            Id = 53L,
                            Name = "Yo Momma Jokes"
                        });
                });

            modelBuilder.Entity("Core.Entities.Flag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Flags");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "NSFW"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Religious"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Political"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Racist"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Sexist"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Adult"
                        });
                });

            modelBuilder.Entity("Core.Entities.Joke", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Jokes");
                });

            modelBuilder.Entity("Core.Entities.JokeFlag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("FlagId")
                        .HasColumnType("bigint");

                    b.Property<long>("JokeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FlagId");

                    b.HasIndex("JokeId");

                    b.ToTable("JokeFlags");
                });

            modelBuilder.Entity("Core.Entities.Part", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("JokeId")
                        .HasColumnType("bigint");

                    b.Property<string>("JokePart")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JokeId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("Core.Entities.Rating", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("JokeId")
                        .HasColumnType("bigint");

                    b.Property<float>("JokeRating")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("JokeId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Core.Entities.Joke", b =>
                {
                    b.HasOne("Core.Entities.Category", "Category")
                        .WithMany("Jokes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Core.Entities.JokeFlag", b =>
                {
                    b.HasOne("Core.Entities.Flag", "Flag")
                        .WithMany("JokeFlags")
                        .HasForeignKey("FlagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Joke", "Joke")
                        .WithMany("JokeFlags")
                        .HasForeignKey("JokeId");

                    b.Navigation("Flag");

                    b.Navigation("Joke");
                });

            modelBuilder.Entity("Core.Entities.Part", b =>
                {
                    b.HasOne("Core.Entities.Joke", "Joke")
                        .WithMany("JokeParts")
                        .HasForeignKey("JokeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Joke");
                });

            modelBuilder.Entity("Core.Entities.Rating", b =>
                {
                    b.HasOne("Core.Entities.Joke", "Joke")
                        .WithMany("JokeRatings")
                        .HasForeignKey("JokeId");

                    b.Navigation("Joke");
                });

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.Navigation("Jokes");
                });

            modelBuilder.Entity("Core.Entities.Flag", b =>
                {
                    b.Navigation("JokeFlags");
                });

            modelBuilder.Entity("Core.Entities.Joke", b =>
                {
                    b.Navigation("JokeFlags");

                    b.Navigation("JokeParts");

                    b.Navigation("JokeRatings");
                });
#pragma warning restore 612, 618
        }
    }
}
