﻿using apiAEE.Entities;
using Microsoft.EntityFrameworkCore;

namespace apiAEE.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Midia> Midias { get; set; }
        public DbSet<Amistoso> Amistosos { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Participar> Participas { get; set; }
        public DbSet<Membro> Membros { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da tabela associativa "Pertence"
            modelBuilder.Entity<Membro>()
                .HasKey(p => new { p.CodEquipe, p.ID});

            modelBuilder.Entity<Membro>()
                .HasOne(p => p.Equipe)
                .WithMany(e => e.Membros)
                .HasForeignKey(p => p.CodEquipe)
                .OnDelete(DeleteBehavior.Restrict); // Evita cascatas desnecessárias

            modelBuilder.Entity<Membro>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Membros)
                .HasForeignKey(p => p.ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar a tabela intermediária "Cadastrar"
            modelBuilder.Entity<Inscricao>()
                .HasKey(c => new { c.CodEquipe, c.CodEvento }); // Definir chave composta

            modelBuilder.Entity<Inscricao>()
                .HasOne(c => c.Equipe) // Relacionamento com "Equipe"
                .WithMany(e => e.Inscricoes) // Uma equipe pode estar em várias inscrições
                .HasForeignKey(c => c.CodEquipe) // Chave estrangeira
                .OnDelete(DeleteBehavior.Cascade); // Comportamento de exclusão em cascata

            modelBuilder.Entity<Inscricao>()
                .HasOne(c => c.Evento) // Relacionamento com "Evento"
                .WithMany(e => e.Inscricoes) // Um evento pode ter várias equipes inscritas
                .HasForeignKey(c => c.CodEvento) // Chave estrangeira
                .OnDelete(DeleteBehavior.Cascade); // Comportamento de exclusão em cascat

            modelBuilder.Entity<Participar>()
                .HasKey(p => new { p.CodEquipe, p.CodEvento, p.CodPartida }); // Define a chave composta

            // Relacionamento entre Participar e Cadastrar
            modelBuilder.Entity<Participar>()
                .HasOne(p => p.Inscricao)
                .WithMany(c => c.Participar)
                .HasForeignKey(p => new { p.CodEquipe, p.CodEvento })
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre Participar e Partida
            modelBuilder.Entity<Participar>()
                .HasOne(p => p.Partida)
                .WithMany(pa => pa.Participar)
                .HasForeignKey(p => p.CodPartida)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Amistoso>()
                .HasKey(p => new { p.CodEquipe, p.CodPartida }); // Define a chave composta

            
            modelBuilder.Entity<Amistoso>()
                .HasOne(p => p.Equipe)
                .WithMany(c => c.Amistoso)
                .HasForeignKey(p => new { p.CodEquipe})
                .OnDelete(DeleteBehavior.Cascade);

          
            modelBuilder.Entity<Amistoso>()
                .HasOne(p => p.Partida)
                .WithMany(pa => pa.Amistoso)
                .HasForeignKey(p => p.CodPartida)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Midia>()
            .HasOne(m => m.Evento)
            .WithMany(e => e.Midias) // Supondo que o Evento tenha uma coleção de Midias
            .HasForeignKey(m => m.CodEvento)
            .OnDelete(DeleteBehavior.Cascade); // Exclui as mídias associadas ao excluir o evento

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");


            base.OnModelCreating(modelBuilder);
        }
    }
}
