using System;
using System.Collections.Generic;

namespace PlataformaAPI.Models;

public partial class Curso
{
    public int CursoId { get; set; }

    public string Titulo { get; set; }

    public string Descripcion { get; set; }

    public string Imagen { get; set; }

    public int Duracion { get; set; }

    public string NivelDificultad { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Evaluacione> Evaluaciones { get; set; } = new List<Evaluacione>();

    public virtual ICollection<Leccione> Lecciones { get; set; } = new List<Leccione>();
}
