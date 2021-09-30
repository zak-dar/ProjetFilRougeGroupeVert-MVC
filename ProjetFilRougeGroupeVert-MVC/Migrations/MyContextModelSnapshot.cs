﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetFilRougeGroupeVert_MVC.Context;

namespace ProjetFilRougeGroupeVert_MVC.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetFilRouge.Models.Canal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstActif")
                        .HasColumnType("bit");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("channel");
                });

            modelBuilder.Entity("ProjetFilRouge.Models.Commentaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuteurId")
                        .HasColumnType("int");

                    b.Property<string>("Contenu")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<int?>("PublicationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuteurId");

                    b.HasIndex("PublicationId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("ProjetFilRouge.Models.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateNaissance")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("mail");

                    b.Property<string>("MotDePasse")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("PersonneType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("person");

                    b.HasDiscriminator<string>("PersonneType").HasValue("Personne");
                });

            modelBuilder.Entity("ProjetFilRouge.Models.Publication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuteurId")
                        .HasColumnType("int");

                    b.Property<int?>("CanalId")
                        .HasColumnType("int");

                    b.Property<string>("Contenu")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contents");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<bool>("Validite")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AuteurId");

                    b.HasIndex("CanalId");

                    b.ToTable("publication");
                });

            modelBuilder.Entity("ProjetFilRouge.Models.Administrateur", b =>
                {
                    b.HasBaseType("ProjetFilRouge.Models.Personne");

                    b.HasDiscriminator().HasValue("admin");
                });

            modelBuilder.Entity("ProjetFilRouge.Models.Utilisateur", b =>
                {
                    b.HasBaseType("ProjetFilRouge.Models.Personne");

                    b.Property<bool>("Valide")
                        .HasColumnType("bit")
                        .HasColumnName("valid");

                    b.HasDiscriminator().HasValue("user");
                });

            modelBuilder.Entity("ProjetFilRouge.Models.Commentaire", b =>
                {
                    b.HasOne("ProjetFilRouge.Models.Utilisateur", "Auteur")
                        .WithMany("Commentaires")
                        .HasForeignKey("AuteurId");

                    b.HasOne("ProjetFilRouge.Models.Publication", "Publication")
                        .WithMany("Commentaires")
                        .HasForeignKey("PublicationId");

                    b.Navigation("Auteur");

                    b.Navigation("Publication");
                });

            modelBuilder.Entity("ProjetFilRouge.Models.Publication", b =>
                {
                    b.HasOne("ProjetFilRouge.Models.Utilisateur", "Auteur")
                        .WithMany("Publications")
                        .HasForeignKey("AuteurId");

                    b.HasOne("ProjetFilRouge.Models.Canal", "Canal")
                        .WithMany("Publications")
                        .HasForeignKey("CanalId");

                    b.Navigation("Auteur");

                    b.Navigation("Canal");
                });

            modelBuilder.Entity("ProjetFilRouge.Models.Canal", b =>
                {
                    b.Navigation("Publications");
                });

            modelBuilder.Entity("ProjetFilRouge.Models.Publication", b =>
                {
                    b.Navigation("Commentaires");
                });

            modelBuilder.Entity("ProjetFilRouge.Models.Utilisateur", b =>
                {
                    b.Navigation("Commentaires");

                    b.Navigation("Publications");
                });
#pragma warning restore 612, 618
        }
    }
}
