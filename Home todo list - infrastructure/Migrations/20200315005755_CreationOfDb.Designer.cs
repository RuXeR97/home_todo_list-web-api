﻿// <auto-generated />
using System;
using Home_todo_list___infrastructure.Other;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Home_todo_list___infrastructure.Migrations
{
    [DbContext(typeof(HomeTodoListDbContext))]
    [Migration("20200315005755_CreationOfDb")]
    partial class CreationOfDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.ProjectAuthor", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectAuthor");
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.ProjectRight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectRights");
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("PredictionTimeMinutes")
                        .HasColumnType("time");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("RealOverallTimeMinutes")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "William",
                            LastName = "Shakespeare",
                            Username = "xd"
                        });
                });

            modelBuilder.Entity("Home_todo_list___infrastructure.Entities.UserProjectRight", b =>
                {
                    b.Property<int>("ProjectRightId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("ProjectRightId", "UserId");

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
                    b.HasOne("Home_todo_list___infrastructure.Entities.Project", null)
                        .WithMany("UsersAllowed")
                        .HasForeignKey("ProjectId");

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