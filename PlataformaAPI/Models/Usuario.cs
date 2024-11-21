using System;
using System.Collections.Generic;

namespace PlataformaAPI.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public int? Nivel { get; set; }

    public int? Puntos { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? UltimaConexion { get; set; }

    public int? RolId { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<LogrosUsuario> LogrosUsuarios { get; set; } = new List<LogrosUsuario>();

    public virtual ICollection<Progreso> Progresos { get; set; } = new List<Progreso>();

    public virtual ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();

    public virtual ICollection<RespuestasEvaluacione> RespuestasEvaluaciones { get; set; } = new List<RespuestasEvaluacione>();

    public virtual Role Rol { get; set; }
}
