using Microsoft.EntityFrameworkCore;
using ProjetFilRouge.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRougeGroupeVert_MVC.Context
{
    public class MyContext : DbContext
    {
        public MyContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Table Personne
            modelBuilder.Entity<Personne>().ToTable("person");
            modelBuilder.Entity<Personne>().Property(p => p.Id).HasColumnName("id");
            modelBuilder.Entity<Personne>().Property(p => p.DateNaissance).HasColumnName("birth_date");
            modelBuilder.Entity<Personne>().Property(p => p.Nom).HasColumnName("last_name");
            modelBuilder.Entity<Personne>().Property(p => p.Prenom).HasColumnName("first_name");
            modelBuilder.Entity<Personne>().Property(p => p.Email).HasColumnName("mail");
            modelBuilder.Entity<Personne>().Property(p => p.MotDePasse).HasColumnName("password");
            modelBuilder.Entity<Personne>().Property(u => u.Role).HasConversion<String>();
            modelBuilder.Entity<Personne>().HasDiscriminator(p => p.PersonneType).HasValue<Utilisateur>("user").HasValue<Administrateur>("admin");
            #endregion

            #region Table Canal
            modelBuilder.Entity<Canal>().ToTable("channel");
            modelBuilder.Entity<Canal>().Property(c => c.Id).HasColumnName("id");
            modelBuilder.Entity<Canal>().Property(c => c.Nom).HasColumnName("name");
            modelBuilder.Entity<Canal>().Property(c => c.Id).HasColumnName("id");
            modelBuilder.Entity<Canal>().HasMany(c => c.Publications).WithOne(p => p.Canal).HasForeignKey(p => p.CanalId);
            #endregion

            #region Table Administrateur
            #endregion

            #region Table Commentaire
            modelBuilder.Entity<Commentaire>().ToTable("comments");
            modelBuilder.Entity<Commentaire>().Property(c => c.Id).HasColumnName("id");
            modelBuilder.Entity<Commentaire>().Property(c => c.Date).HasColumnName("date");
            modelBuilder.Entity<Commentaire>().Property(c => c.Contenu).HasColumnName("content");
            #endregion

            #region Table Publication
            modelBuilder.Entity<Publication>().ToTable("publication");
            modelBuilder.Entity<Publication>().Property(p => p.Id).HasColumnName("id");
            modelBuilder.Entity<Publication>().Property(p => p.Date).HasColumnName("date");
            modelBuilder.Entity<Publication>().Property(p => p.Titre).HasColumnName("title");
            modelBuilder.Entity<Publication>().Property(p => p.Contenu).HasColumnName("contents");
            modelBuilder.Entity<Publication>().HasMany(p => p.Commentaires).WithOne(c => c.Publication).HasForeignKey(c => c.PublicationId);
            #endregion

            #region Table Utilisateur
            modelBuilder.Entity<Utilisateur>().Property(u => u.Valide).HasColumnName("valid");
            modelBuilder.Entity<Utilisateur>().HasMany(u => u.Publications).WithOne(p => p.Auteur).HasForeignKey(p => p.AuteurId);
            modelBuilder.Entity<Utilisateur>().HasMany(u => u.Commentaires).WithOne(c => c.Auteur).HasForeignKey(c => c.AuteurId);
            #endregion

        }
        public DbSet<ProjetFilRouge.Models.Publication> Publication { get; set; }
        public DbSet<ProjetFilRouge.Models.Utilisateur> Utilisateur { get; set; }
        public DbSet<ProjetFilRouge.Models.Canal> Canal { get; set; }
        public DbSet<ProjetFilRouge.Models.Administrateur> Administrateur { get; set; }
    }

}
