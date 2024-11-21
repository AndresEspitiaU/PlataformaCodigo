using System;
using System.Collections.Generic;

namespace PlataformaAPI.Models;

public partial class Ejercicio
{
    public int EjercicioId { get; set; }

    public string Tipo { get; set; }

    public string Pregunta { get; set; }

    public string SolucionEsperada { get; set; }

    public string Opciones { get; set; }

    public string Dificultad { get; set; }

    public string PruebasUnitarias { get; set; }

    public string EjemploSolucion { get; set; }

    public int? Puntos { get; set; }

    public int Orden { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public int LeccionId { get; set; }

    public virtual Leccione Leccion { get; set; }
}
