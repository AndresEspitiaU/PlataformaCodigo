using System;
using System.Collections.Generic;

namespace PlataformaAPI.Models;

public partial class Leccione
{
    public int LeccionId { get; set; }

    public string Titulo { get; set; }

    public string Contenido { get; set; }

    public int TiempoEstimado { get; set; }

    public string PalabrasClave { get; set; }

    public string ContenidoExtra { get; set; }

    public int Orden { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public int CursoId { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Curso Curso { get; set; }

    public virtual ICollection<Ejercicio> Ejercicios { get; set; } = new List<Ejercicio>();

    public virtual ICollection<Progreso> Progresos { get; set; } = new List<Progreso>();
}
