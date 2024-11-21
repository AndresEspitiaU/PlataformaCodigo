using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaAPI.Dto
{
    public class CursoDto
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; } // URL de la imagen
        public int Duracion { get; set; } // Duración en horas
        public string NivelDificultad { get; set; } // Básico, Intermedio, Avanzado
        public bool Activo { get; set; } // Si el curso está activo o no
    }
}