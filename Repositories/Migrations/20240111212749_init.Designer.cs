﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories;

#nullable disable

namespace Repositories.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240111212749_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Auteur")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Contenu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCre")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateMod")
                        .HasColumnType("datetime2");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Auteur = "Lilyah",
                            Contenu = "Rien",
                            DateCre = new DateTime(2012, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Theme = "Les Réseaux Sociaux"
                        },
                        new
                        {
                            Id = 2,
                            Auteur = "Kezyah",
                            Contenu = "Y en a plein, c'est beau une licorne",
                            DateCre = new DateTime(2016, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Theme = "Des licornes dans les contes de fées"
                        },
                        new
                        {
                            Id = 3,
                            Auteur = "Wakko",
                            Contenu = "But does it djent ?",
                            DateCre = new DateTime(1981, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Theme = "C# rocks !"
                        });
                });

            modelBuilder.Entity("Entities.Commentaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Auteur")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Contenu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCre")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateMod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("Entities.Commentaire", b =>
                {
                    b.HasOne("Entities.Article", null)
                        .WithMany("Commentaires")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Article", b =>
                {
                    b.Navigation("Commentaires");
                });
#pragma warning restore 612, 618
        }
    }
}
