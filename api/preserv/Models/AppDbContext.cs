using Microsoft.EntityFrameworkCore;

namespace PreservWebApi.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UnidadeTempo> UnidadesTempo { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Log> Logs { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Perfil>().ToTable("Perfil");
            builder.Entity<Perfil>().HasKey(r => r.IdPerfil);
            builder.Entity<Perfil>().Property(r => r.IdPerfil).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Perfil>().Property(r => r.Descricao).IsRequired().HasMaxLength(255);
            builder.Entity<Perfil>().Property(r => r.DataCriacao);
            builder.Entity<Perfil>().HasMany(r => r.Usuarios).WithOne(r => r.Perfil).HasForeignKey(r => r.IdPerfil);

            builder.Entity<Usuario>().ToTable("Usuario");
            builder.Entity<Usuario>().HasKey(r => r.IdUsuario);
            builder.Entity<Usuario>().Property(r => r.IdUsuario).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Usuario>().Property(r => r.Login).IsRequired().HasMaxLength(16);
            builder.Entity<Usuario>().Property(r => r.Senha).IsRequired().HasMaxLength(32);
            builder.Entity<Usuario>().Property(r => r.Email).IsRequired().HasMaxLength(255);
            builder.Entity<Usuario>().Property(r => r.ChaveAcesso).HasMaxLength(32);
            builder.Entity<Usuario>().Property(r => r.IdPerfil);
            builder.Entity<Usuario>().Property(r => r.DataCriacao);
            builder.Entity<Usuario>().HasOne(x => x.Perfil).WithMany(x => x.Usuarios).HasForeignKey(x => x.IdPerfil);

            builder.Entity<Categoria>().ToTable("Categoria");
            builder.Entity<Categoria>().HasKey(r => r.IdCategoria);
            builder.Entity<Categoria>().Property(r => r.IdCategoria).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Categoria>().Property(r => r.Descricao).IsRequired().HasMaxLength(255);
            builder.Entity<Categoria>().Property(r => r.DataCriacao);
            builder.Entity<Categoria>().HasMany(r => r.Projetos).WithOne(r => r.Categoria).HasForeignKey(r => r.IdCategoria);

            builder.Entity<UnidadeTempo>().ToTable("UnidadeTempo");
            builder.Entity<UnidadeTempo>().HasKey(r => r.IdUnidadeTempo);
            builder.Entity<UnidadeTempo>().Property(r => r.IdUnidadeTempo).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UnidadeTempo>().Property(r => r.Descricao).IsRequired().HasMaxLength(255);
            builder.Entity<UnidadeTempo>().Property(r => r.DataCriacao);
            
            builder.Entity<Log>().ToTable("Log");
            builder.Entity<Log>().HasKey(r => r.IdLog);
            builder.Entity<Log>().Property(r => r.IdLog).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Log>().Property(r => r.IdUsuario).IsRequired();
            builder.Entity<Log>().Property(r => r.Acao).IsRequired().HasMaxLength(255);
            builder.Entity<Log>().Property(r => r.Pagina).IsRequired().HasMaxLength(255);
            builder.Entity<Log>().Property(r => r.DataCriacao);
            builder.Entity<Log>().HasOne(x => x.Usuario).WithMany(x => x.Logs).HasForeignKey(x => x.IdUsuario);
            
            builder.Entity<Projeto>().ToTable("Projeto");
            builder.Entity<Projeto>().HasKey(r => r.IdProjeto);
            builder.Entity<Projeto>().Property(r => r.IdProjeto).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Projeto>().Property(r => r.IdUnidadeTempo).IsRequired();
            builder.Entity<Projeto>().Property(r => r.IdCategoria).IsRequired();
            builder.Entity<Projeto>().Property(r => r.Descricao).IsRequired().HasMaxLength(255);
            builder.Entity<Projeto>().Property(r => r.PrazoPrevistoMinimo);
            builder.Entity<Projeto>().Property(r => r.PrazoPrevistoMaximo);
            builder.Entity<Projeto>().Property(r => r.ValorPrevisto);
            builder.Entity<Projeto>().Property(r => r.DataCriacao);
            builder.Entity<Projeto>().HasOne(x => x.UnidadeTempo).WithMany(x => x.Projetos).HasForeignKey(x => x.IdUnidadeTempo);
            builder.Entity<Projeto>().HasOne(x => x.Categoria).WithMany(x => x.Projetos).HasForeignKey(x => x.IdCategoria);
            
            builder.Entity<Tarefa>().ToTable("Tarefa");
            builder.Entity<Tarefa>().HasKey(r => r.IdTarefa);
            builder.Entity<Tarefa>().Property(r => r.IdTarefa).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tarefa>().Property(r => r.IdProjeto);
            builder.Entity<Tarefa>().Property(r => r.IdUnidadeTempo).IsRequired();
            builder.Entity<Tarefa>().Property(r => r.Descricao).IsRequired().HasMaxLength(255);
            builder.Entity<Tarefa>().Property(r => r.DataInicio);
            builder.Entity<Tarefa>().Property(r => r.DataEncerramento);
            builder.Entity<Tarefa>().Property(r => r.DataCriacao);
            builder.Entity<Tarefa>().HasOne(x => x.UnidadeTempo).WithMany(x => x.Tarefas).HasForeignKey(x => x.IdUnidadeTempo);
            builder.Entity<Tarefa>().HasOne(x => x.Projeto).WithMany(x => x.Tarefas).HasForeignKey(x => x.IdProjeto);
            
            builder.Entity<Contrato>().ToTable("Contrato");
            builder.Entity<Contrato>().HasKey(r => r.IdContrato);
            builder.Entity<Contrato>().Property(r => r.IdContrato).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Contrato>().Property(r => r.IdProjeto);
            builder.Entity<Contrato>().Property(r => r.IdContratante).IsRequired();
            builder.Entity<Contrato>().Property(r => r.IdContratado).IsRequired();
            builder.Entity<Contrato>().Property(r => r.Descricao).IsRequired().HasMaxLength(255);
            builder.Entity<Contrato>().Property(r => r.ValorContratado).IsRequired().HasMaxLength(16);
            builder.Entity<Contrato>().Property(r => r.DataCriacao);
            builder.Entity<Contrato>().Property(r => r.DataEncerramento);
            builder.Entity<Contrato>().HasOne(x => x.Projeto).WithMany(x => x.Contratos).HasForeignKey(x => x.IdProjeto);
            builder.Entity<Contrato>().HasOne(x => x.Contratante).WithMany(x => x.Contratos).HasForeignKey(x => x.IdContratante);
            builder.Entity<Contrato>().HasOne(x => x.Contratado).WithMany(x => x.Contratos).HasForeignKey(x => x.IdContratado);            
        }
    }
}