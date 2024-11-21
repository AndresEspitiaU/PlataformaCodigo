using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlataformaAPI.Dto;
using PlataformaAPI.Models;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrador")]
public class CursosController : ControllerBase
{
    private readonly AprendeCodigoContext _context;

    public CursosController(AprendeCodigoContext context)
    {
        _context = context;
    }

    // Crear un curso
    [HttpPost]
    public async Task<IActionResult> CreateCurso([FromBody] CursoDto cursoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var curso = new Curso
        {
            Titulo = cursoDto.Titulo,
            Descripcion = cursoDto.Descripcion,
            Imagen = cursoDto.Imagen,
            Duracion = cursoDto.Duracion,
            NivelDificultad = cursoDto.NivelDificultad,
            Activo = cursoDto.Activo,
            FechaCreacion = DateTime.Now
        };

        _context.Cursos.Add(curso);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCurso), new { id = curso.CursoId }, curso);
    }

    // Actualizar un curso
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCurso(int id, [FromBody] CursoDto cursoDto)
    {
        var curso = await _context.Cursos.FindAsync(id);
        if (curso == null)
        {
            return NotFound("Curso no encontrado.");
        }

        // Actualizar campos
        curso.Titulo = cursoDto.Titulo;
        curso.Descripcion = cursoDto.Descripcion;
        curso.Imagen = cursoDto.Imagen;
        curso.Duracion = cursoDto.Duracion;
        curso.NivelDificultad = cursoDto.NivelDificultad;
        curso.Activo = cursoDto.Activo;
        curso.FechaActualizacion = DateTime.Now;

        await _context.SaveChangesAsync();

        return Ok(curso);
    }

    // Eliminar un curso
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCurso(int id)
    {
        var curso = await _context.Cursos.FindAsync(id);
        if (curso == null)
        {
            return NotFound("Curso no encontrado.");
        }

        _context.Cursos.Remove(curso);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Obtener un curso (opcional para validación de creación)
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCurso(int id)
    {
        var curso = await _context.Cursos
            .Select(c => new
            {
                c.CursoId,
                c.Titulo,
                c.Descripcion,
                c.Imagen,
                c.Duracion,
                c.NivelDificultad,
                c.Activo,
                c.FechaCreacion,
                c.FechaActualizacion
            })
            .FirstOrDefaultAsync(c => c.CursoId == id);

        if (curso == null)
        {
            return NotFound("Curso no encontrado.");
        }

        return Ok(curso);
    }
}
