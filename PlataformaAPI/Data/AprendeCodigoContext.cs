using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PlataformaAPI.Models;

public partial class AprendeCodigoContext : DbContext
{
    public AprendeCodigoContext()
    {
    }

    public AprendeCodigoContext(DbContextOptions<AprendeCodigoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Ejercicio> Ejercicios { get; set; }

    public virtual DbSet<Evaluacione> Evaluaciones { get; set; }

    public virtual DbSet<Leccione> Lecciones { get; set; }

    public virtual DbSet<Logro> Logros { get; set; }

    public virtual DbSet<LogrosUsuario> LogrosUsuarios { get; set; }

    public virtual DbSet<Progreso> Progresos { get; set; }

    public virtual DbSet<Ranking> Rankings { get; set; }

    public virtual DbSet<RespuestasEvaluacione> RespuestasEvaluaciones { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=bdandresespitia.database.windows.net,1433;Database=AprendeCodigo;User Id=andresespitia;Password=Soypipe23@;Encrypt=True;TrustServerCertificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.ComentarioId).HasName("PK__Comentar__F18449386B9ED342");

            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Texto).IsRequired();

            entity.HasOne(d => d.Curso).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("FK__Comentari__Curso__17036CC0");

            entity.HasOne(d => d.Leccion).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.LeccionId)
                .HasConstraintName("FK__Comentari__Lecci__17F790F9");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__Usuar__160F4887");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CursoId).HasName("PK__Cursos__7E0235D73FF9BF0F");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).IsRequired();
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Imagen).HasMaxLength(255);
            entity.Property(e => e.NivelDificultad)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Titulo)
                .IsRequired()
                .HasMaxLength(200);
        });

        modelBuilder.Entity<Ejercicio>(entity =>
        {
            entity.HasKey(e => e.EjercicioId).HasName("PK__Ejercici__81222641FB9DC19F");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Dificultad)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Pregunta).IsRequired();
            entity.Property(e => e.Puntos).HasDefaultValue(10);
            entity.Property(e => e.Tipo)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Leccion).WithMany(p => p.Ejercicios)
                .HasForeignKey(d => d.LeccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ejercicio__Lecci__6E01572D");
        });

        modelBuilder.Entity<Evaluacione>(entity =>
        {
            entity.HasKey(e => e.EvaluacionId).HasName("PK__Evaluaci__99ABA745453F76DD");

            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Preguntas).IsRequired();
            entity.Property(e => e.Soluciones).IsRequired();
            entity.Property(e => e.TipoEvaluacion)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.Curso).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Evaluacio__Curso__08B54D69");
        });

        modelBuilder.Entity<Leccione>(entity =>
        {
            entity.HasKey(e => e.LeccionId).HasName("PK__Leccione__5C59E7C3A23AB3A0");

            entity.HasIndex(e => e.CursoId, "IX_Lecciones_CursoId");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Contenido).IsRequired();
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PalabrasClave).HasMaxLength(255);
            entity.Property(e => e.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.Curso).WithMany(p => p.Lecciones)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lecciones__Curso__68487DD7");
        });

        modelBuilder.Entity<Logro>(entity =>
        {
            entity.HasKey(e => e.LogroId).HasName("PK__Logros__A54B4F409C412777");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).IsRequired();
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Icono).HasMaxLength(255);
            entity.Property(e => e.Puntos).HasDefaultValue(50);
            entity.Property(e => e.TipoLogro)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Titulo)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Visible).HasDefaultValue(true);
        });

        modelBuilder.Entity<LogrosUsuario>(entity =>
        {
            entity.HasKey(e => e.LogroUsuarioId).HasName("PK__LogrosUs__641DE0D2E1554B17");

            entity.Property(e => e.FechaDesbloqueo)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Logro).WithMany(p => p.LogrosUsuarios)
                .HasForeignKey(d => d.LogroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LogrosUsu__Logro__01142BA1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.LogrosUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LogrosUsu__Usuar__00200768");
        });

        modelBuilder.Entity<Progreso>(entity =>
        {
            entity.HasKey(e => e.ProgresoId).HasName("PK__Progreso__B9EABD66661A88CB");

            entity.ToTable("Progreso");

            entity.HasIndex(e => e.UsuarioId, "IX_Progreso_UsuarioId");

            entity.Property(e => e.Completado).HasDefaultValue(false);
            entity.Property(e => e.ErroresCometidos).HasDefaultValue(0);
            entity.Property(e => e.FechaCompletado).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PuntosObtenidos).HasDefaultValue(0);
            entity.Property(e => e.TiempoTotal).HasDefaultValue(0);

            entity.HasOne(d => d.Leccion).WithMany(p => p.Progresos)
                .HasForeignKey(d => d.LeccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Progreso__Leccio__76969D2E");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Progresos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Progreso__Usuari__75A278F5");
        });

        modelBuilder.Entity<Ranking>(entity =>
        {
            entity.HasKey(e => e.RankingId).HasName("PK__Ranking__018A6AD9095A2B42");

            entity.ToTable("Ranking");

            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ranking__Usuario__04E4BC85");
        });

        modelBuilder.Entity<RespuestasEvaluacione>(entity =>
        {
            entity.HasKey(e => e.RespuestaEvaluacionId).HasName("PK__Respuest__5140557C252A3EE5");

            entity.Property(e => e.Correctas).HasDefaultValue(0);
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Incorrectas).HasDefaultValue(0);
            entity.Property(e => e.PuntosObtenidos).HasDefaultValue(0);
            entity.Property(e => e.TiempoEmpleado).HasDefaultValue(0);

            entity.HasOne(d => d.Evaluacion).WithMany(p => p.RespuestasEvaluaciones)
                .HasForeignKey(d => d.EvaluacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__Evalu__114A936A");

            entity.HasOne(d => d.Usuario).WithMany(p => p.RespuestasEvaluaciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__Usuar__10566F31");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302F1677ED82B");

            entity.HasIndex(e => e.Nombre, "UQ__Roles__75E3EFCF6E59C228").IsUnique();

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B863E8F9B8");

            entity.HasIndex(e => e.Email, "IX_Usuarios_Email");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D1053491FE81D4").IsUnique();

            entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nivel).HasDefaultValue(1);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Puntos).HasDefaultValue(0);
            entity.Property(e => e.UltimaConexion).HasColumnType("datetime");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
