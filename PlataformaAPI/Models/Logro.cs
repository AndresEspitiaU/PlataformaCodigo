using System;
using System.Collections.Generic;

namespace PlataformaAPI.Models;

public partial class Logro
{
    public int LogroId { get; set; }

    public string Titulo { get; set; }

    public string Descripcion { get; set; }

    public int? Puntos { get; set; }

    public string Icono { get; set; }

    public string TipoLogro { get; set; }

    public bool? Visible { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<LogrosUsuario> LogrosUsuarios { get; set; } = new List<LogrosUsuario>();
}
