using System;
using System.Collections.Generic;

namespace PlataformaAPI.Models;

public partial class Ranking
{
    public int RankingId { get; set; }

    public int Puntos { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public int UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; }
}
