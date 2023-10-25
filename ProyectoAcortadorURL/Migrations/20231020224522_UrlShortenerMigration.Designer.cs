﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoAcortadorURL.Data;

#nullable disable

namespace ProyectoAcortadorURL.Migrations
{
    [DbContext(typeof(UrlShortenerContext))]
    [Migration("20231020224522_UrlShortenerMigration")]
    partial class UrlShortenerMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("ProyectoAcortadorURL.Entities.ShortenedURL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LongURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ShortenedUrls", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
