﻿// <auto-generated />
using System;
using BakTraCam.Core.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BakTraCam.Core.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200916090021_bakim_baslangic_bitis_tarih_eklendi")]
    partial class bakim_baslangic_bitis_tarih_eklendi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("BakTraCam.Core.Entity.BakimEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ad")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BaslangicTarihi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BitisTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("Durum")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gerceklestiren1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gerceklestiren2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gerceklestiren3")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gerceklestiren4")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Period")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sorumlu1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sorumlu2")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Tarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tip")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("tBakim");
                });

            modelBuilder.Entity("BakTraCam.Core.Entity.KullaniciEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ad")
                        .HasColumnType("TEXT");

                    b.Property<int>("UnvanId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("tKullanici");
                });

            modelBuilder.Entity("BakTraCam.Service.DataContract.BakimModelBasic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ad")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BaslangicTarihi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BitisTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("Durum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gerceklestiren1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gerceklestiren2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gerceklestiren3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gerceklestiren4")
                        .HasColumnType("TEXT");

                    b.Property<int>("Period")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sorumlu1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sorumlu2")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tip")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Bakims");
                });
#pragma warning restore 612, 618
        }
    }
}
