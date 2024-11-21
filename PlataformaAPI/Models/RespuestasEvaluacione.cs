using System;
using System.Collections.Generic;

namespace PlataformaAPI.Models;

public partial class RespuestasEvaluacione
{
    public int RespuestaEvaluacionId { get; set; }

    public string Respuestas { get; set; }

    public int? Correctas { get; set; }

    public int? Incorrectas { get; set; }

    public int? TiempoEmpleado { get; set; }

    public int? PuntosObtenidos { get; set; }

    public DateTime? Fecha { get; set; }

    public int UsuarioId { get; set; }

    public int EvaluacionId { get; set; }

    public virtual Evaluacione Evaluacion { get; set; }

    public virtual Usuario Usuario { get; set; }
}
