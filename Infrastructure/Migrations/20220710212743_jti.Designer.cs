﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220710212743_jti")]
    partial class jti
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApplicationCore.Models.Community", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Communities", (string)null);
                });

            modelBuilder.Entity("ApplicationCore.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CommunityId")
                        .HasColumnType("int");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CommunityId");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("Posts", (string)null);
                });

            modelBuilder.Entity("ApplicationCore.Models.PostMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostMedias", (string)null);
                });

            modelBuilder.Entity("ApplicationCore.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Jti")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserAgent")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions", (string)null);
                });

            modelBuilder.Entity("ApplicationCore.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ApplicationCore.Models.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VoteType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Votes", (string)null);
                });

            modelBuilder.Entity("CommunityUser", b =>
                {
                    b.Property<int>("CommunitiesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("CommunitiesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("CommunityUser");
                });

            modelBuilder.Entity("ApplicationCore.Models.Community", b =>
                {
                    b.HasOne("ApplicationCore.Models.User", "CreatorUser")
                        .WithMany("CreatedCommunities")
                        .HasForeignKey("CreatorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatorUser");
                });

            modelBuilder.Entity("ApplicationCore.Models.Post", b =>
                {
                    b.HasOne("ApplicationCore.Models.Community", "Community")
                        .WithMany("Posts")
                        .HasForeignKey("CommunityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Models.User", "CreatorUser")
                        .WithMany("Posts")
                        .HasForeignKey("CreatorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Community");

                    b.Navigation("CreatorUser");
                });

            modelBuilder.Entity("ApplicationCore.Models.PostMedia", b =>
                {
                    b.HasOne("ApplicationCore.Models.Post", "Post")
                        .WithMany("Medias")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("ApplicationCore.Models.Session", b =>
                {
                    b.HasOne("ApplicationCore.Models.User", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApplicationCore.Models.Vote", b =>
                {
                    b.HasOne("ApplicationCore.Models.Post", "Post")
                        .WithMany("Votes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Models.User", "User")
                        .WithMany("Votes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CommunityUser", b =>
                {
                    b.HasOne("ApplicationCore.Models.Community", null)
                        .WithMany()
                        .HasForeignKey("CommunitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Models.Community", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("ApplicationCore.Models.Post", b =>
                {
                    b.Navigation("Medias");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("ApplicationCore.Models.User", b =>
                {
                    b.Navigation("CreatedCommunities");

                    b.Navigation("Posts");

                    b.Navigation("Sessions");

                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
