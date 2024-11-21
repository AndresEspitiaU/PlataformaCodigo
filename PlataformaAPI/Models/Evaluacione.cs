using System;
using System.Collections.Generic;

namespace PlataformaAPI.Models;

public partial class Evaluacione
{
    public int EvaluacionId { get; set; }

    public string Titulo { get; set; }

    public string Preguntas { get; set; }

    public string Soluciones { get; set; }

    public string TipoEvaluacion { get; set; }

    public string Instrucciones { get; set; }

    public int PuntosTotales { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public int CursoId { get; set; }

    public virtual Curso Curso { get; set; }

    public virtual ICollection<RespuestasEvaluacione> RespuestasEvaluaciones { get; set; } = new List<RespuestasEvaluacione>();
}
