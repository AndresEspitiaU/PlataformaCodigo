using System;
using System.Collections.Generic;

namespace PlataformaAPI.Models;

public partial class Progreso
{
    public int ProgresoId { get; set; }

    public bool? Completado { get; set; }

    public int? PuntosObtenidos { get; set; }

    public int? ErroresCometidos { get; set; }

    public int? TiempoTotal { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaCompletado { get; set; }

    public int UsuarioId { get; set; }

    public int LeccionId { get; set; }

    public virtual Leccione Leccion { get; set; }

    public virtual Usuario Usuario { get; set; }
}
