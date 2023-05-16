﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AMContext))]
    partial class AMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ActivitePack", b =>
                {
                    b.Property<int>("ActivitesActiviteId")
                        .HasColumnType("int");

                    b.Property<int>("PacksPackId")
                        .HasColumnType("int");

                    b.HasKey("ActivitesActiviteId", "PacksPackId");

                    b.HasIndex("PacksPackId");

                    b.ToTable("ActivitePack");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Activite", b =>
                {
                    b.Property<int>("ActiviteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActiviteId"));

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<string>("TypeService")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ActiviteId");

                    b.ToTable("Activites");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Client", b =>
                {
                    b.Property<int>("Identifiant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Identifiant"));

                    b.Property<int>("ConseillerFK")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Identifiant");

                    b.HasIndex("ConseillerFK");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Conseiller", b =>
                {
                    b.Property<int>("ConseillerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConseillerId"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ConseillerId");

                    b.ToTable("Conseillers");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Pack", b =>
                {
                    b.Property<int>("PackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackId"));

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.Property<string>("IntitulePack")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("NbPlaces")
                        .HasColumnType("int");

                    b.HasKey("PackId");

                    b.ToTable("Packs");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Reservation", b =>
                {
                    b.Property<int>("ClientFK")
                        .HasColumnType("int");

                    b.Property<int>("PackFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateReservation")
                        .HasColumnType("datetime2");

                    b.Property<int>("NbPersonnes")
                        .HasColumnType("int");

                    b.HasKey("ClientFK", "PackFK", "DateReservation");

                    b.HasIndex("PackFK");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("ActivitePack", b =>
                {
                    b.HasOne("ApplicationCore.Domain.Activite", null)
                        .WithMany()
                        .HasForeignKey("ActivitesActiviteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Domain.Pack", null)
                        .WithMany()
                        .HasForeignKey("PacksPackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Domain.Activite", b =>
                {
                    b.OwnsOne("ApplicationCore.Domain.Zone", "Zone", b1 =>
                        {
                            b1.Property<int>("ActiviteId")
                                .HasColumnType("int");

                            b1.Property<string>("Pays")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("nvarchar(15)");

                            b1.Property<string>("Ville")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("nvarchar(15)");

                            b1.HasKey("ActiviteId");

                            b1.ToTable("Activites");

                            b1.WithOwner()
                                .HasForeignKey("ActiviteId");
                        });

                    b.Navigation("Zone")
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Domain.Client", b =>
                {
                    b.HasOne("ApplicationCore.Domain.Conseiller", "Conseiller")
                        .WithMany("Clients")
                        .HasForeignKey("ConseillerFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conseiller");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Reservation", b =>
                {
                    b.HasOne("ApplicationCore.Domain.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Domain.Pack", "Pack")
                        .WithMany("Reservations")
                        .HasForeignKey("PackFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Pack");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Conseiller", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Pack", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
