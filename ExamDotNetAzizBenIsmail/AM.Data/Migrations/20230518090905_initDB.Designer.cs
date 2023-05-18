﻿// <auto-generated />
using System;
using AM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.Data.Migrations
{
    [DbContext(typeof(AMContext))]
    [Migration("20230518090905_initDB")]
    partial class initDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AM.Core.Domain.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AM.Core.Domain.Prestataire", b =>
                {
                    b.Property<int>("PrestataireId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrestataireId"), 1L, 1);

                    b.Property<int>("Note")
                        .HasColumnType("int");

                    b.Property<string>("PageInstagram")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PrestataireNom")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PrestataireTel")
                        .HasColumnType("int");

                    b.Property<int>("zone")
                        .HasColumnType("int");

                    b.HasKey("PrestataireId");

                    b.ToTable("Prestataires");
                });

            modelBuilder.Entity("AM.Core.Domain.Prestation", b =>
                {
                    b.Property<int>("PrestationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrestationId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Intitule")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("PrestataireFK")
                        .HasColumnType("int")
                        .HasColumnName("PrestataireFK");

                    b.Property<int>("PrestationType")
                        .HasColumnType("int");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.HasKey("PrestationId");

                    b.HasIndex("PrestataireFK");

                    b.ToTable("Prestations");
                });

            modelBuilder.Entity("AM.Core.Domain.RDV", b =>
                {
                    b.Property<int>("ClientFK")
                        .HasColumnType("int");

                    b.Property<int>("PrestationFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRDV")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Confirmation")
                        .HasColumnType("bit");

                    b.HasKey("ClientFK", "PrestationFK", "DateRDV");

                    b.HasIndex("PrestationFK");

                    b.ToTable("RDVs");
                });

            modelBuilder.Entity("AM.Core.Domain.Prestation", b =>
                {
                    b.HasOne("AM.Core.Domain.Prestataire", "MyPrestataire")
                        .WithMany("MyPrestation")
                        .HasForeignKey("PrestataireFK");

                    b.Navigation("MyPrestataire");
                });

            modelBuilder.Entity("AM.Core.Domain.RDV", b =>
                {
                    b.HasOne("AM.Core.Domain.Client", "MyClient")
                        .WithMany("RDVs")
                        .HasForeignKey("ClientFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.Core.Domain.Prestation", "MyPrestation")
                        .WithMany("RDVs")
                        .HasForeignKey("PrestationFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyClient");

                    b.Navigation("MyPrestation");
                });

            modelBuilder.Entity("AM.Core.Domain.Client", b =>
                {
                    b.Navigation("RDVs");
                });

            modelBuilder.Entity("AM.Core.Domain.Prestataire", b =>
                {
                    b.Navigation("MyPrestation");
                });

            modelBuilder.Entity("AM.Core.Domain.Prestation", b =>
                {
                    b.Navigation("RDVs");
                });
#pragma warning restore 612, 618
        }
    }
}
