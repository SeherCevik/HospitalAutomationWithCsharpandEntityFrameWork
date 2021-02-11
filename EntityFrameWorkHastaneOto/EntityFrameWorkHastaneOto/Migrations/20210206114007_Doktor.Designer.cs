﻿// <auto-generated />
using System;
using EntityFrameWorkHastaneOto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameWorkHastaneOto.Migrations
{
    [DbContext(typeof(HastaneDbContext))]
    [Migration("20210206114007_Doktor")]
    partial class Doktor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DoktorHasta", b =>
                {
                    b.Property<int>("doktorlarID")
                        .HasColumnType("int");

                    b.Property<int>("hastalarID")
                        .HasColumnType("int");

                    b.HasKey("doktorlarID", "hastalarID");

                    b.HasIndex("hastalarID");

                    b.ToTable("DoktorHasta");
                });

            modelBuilder.Entity("EntityFrameWorkHastaneOto.Doktor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("doktorlar");
                });

            modelBuilder.Entity("EntityFrameWorkHastaneOto.Hasta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adi")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TC")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("ID");

                    b.ToTable("Hasta");
                });

            modelBuilder.Entity("EntityFrameWorkHastaneOto.HastaDetay", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("HastaId")
                        .HasColumnType("int");

                    b.Property<int?>("Kilo")
                        .HasColumnType("int");

                    b.Property<int?>("Yas")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("HastaId")
                        .IsUnique();

                    b.ToTable("hastadetaylar");
                });

            modelBuilder.Entity("DoktorHasta", b =>
                {
                    b.HasOne("EntityFrameWorkHastaneOto.Doktor", null)
                        .WithMany()
                        .HasForeignKey("doktorlarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameWorkHastaneOto.Hasta", null)
                        .WithMany()
                        .HasForeignKey("hastalarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameWorkHastaneOto.HastaDetay", b =>
                {
                    b.HasOne("EntityFrameWorkHastaneOto.Hasta", "hasta")
                        .WithOne("hastadetay")
                        .HasForeignKey("EntityFrameWorkHastaneOto.HastaDetay", "HastaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hasta");
                });

            modelBuilder.Entity("EntityFrameWorkHastaneOto.Hasta", b =>
                {
                    b.Navigation("hastadetay");
                });
#pragma warning restore 612, 618
        }
    }
}
