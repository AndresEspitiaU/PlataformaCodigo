using System;
using System.Collections.Generic;

namespace PlataformaAPI.Models;

public partial class LogrosUsuario
{
    public int LogroUsuarioId { get; set; }

    public DateTime? FechaDesbloqueo { get; set; }

    public int UsuarioId { get; set; }

    public int LogroId { get; set; }

    public virtual Logro Logro { get; set; }

    public virtual Usuario Usuario { get; set; }
}
