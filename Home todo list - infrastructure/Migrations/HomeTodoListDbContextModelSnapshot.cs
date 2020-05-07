﻿// <auto-generated />
using System;
using Home_todo_list___infrastructure.Other;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Home_todo_list___infrastructure.Migrations
{
    [DbContext(typeof(HomeTodoListDbContext))]
    partial class HomeTodoListDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.ProjectAuthor", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectAuthor");
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.ProjectRight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProjectRights");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "User can only view project and its tasks.",
                            Name = "READONLY"
                        },
                        new
                        {
                            Id = 2,
                            Description = "User has rights to read, modify and delete project.",
                            Name = "ADMIN"
                        });
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<TimeSpan>("PredictionTimeMinutes")
                        .HasColumnType("interval");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("RealOverallTimeMinutes")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.UserProjectRight", b =>
                {
                    b.Property<int>("ProjectRightId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.HasKey("ProjectRightId", "UserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProjectRight");
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.Project", b =>
                {
                    b.HasOne("Home_todo_list___infrastructure.Entities.User", null)
                        .WithMany("ProjectsAssigned")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.ProjectAuthor", b =>
                {
                    b.HasOne("Home_todo_list___infrastructure.Entities.Project", "Project")
                        .WithMany("ProjectAuthors")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Home_todo_list___infrastructure.Entities.User", "Author")
                        .WithMany("ProjectsOwned")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.Task", b =>
                {
                    b.HasOne("Home_todo_list___infrastructure.Entities.Project", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.UserProjectRight", b =>
                {
                    b.HasOne("Home_todo_list___infrastructure.Entities.Project", "Project")
                        .WithMany("UsersAllowed")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Home_todo_list___infrastructure.Entities.ProjectRight", "ProjectRight")
                        .WithMany()
                        .HasForeignKey("ProjectRightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Home_todo_list___infrastructure.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
