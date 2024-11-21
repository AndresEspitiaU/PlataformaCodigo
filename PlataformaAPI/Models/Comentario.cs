using System;
using System.Collections.Generic;

namespace PlataformaAPI.Models;

public partial class Comentario
{
    public int ComentarioId { get; set; }

    public string Texto { get; set; }

    public DateTime? Fecha { get; set; }

    public int? Calificacion { get; set; }

    public int UsuarioId { get; set; }

    public int? CursoId { get; set; }

    public int? LeccionId { get; set; }

    public virtual Curso Curso { get; set; }

    public virtual Leccione Leccion { get; set; }

    public virtual Usuario Usuario { get; set; }
}
