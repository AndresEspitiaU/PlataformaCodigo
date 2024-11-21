using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlataformaAPI.Dto;
using PlataformaAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AprendeCodigoContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(AprendeCodigoContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    // Registro de Usuario
    [HttpPost("registro")]
    public async Task<IActionResult> RegistrarUsuario(UsuarioRegistroDto registroDto)
    {
        // Validar si el usuario ya existe
        if (_context.Usuarios.Any(u => u.Email == registroDto.Email))
        {
            return BadRequest("El correo ya está registrado.");
        }

        // Buscar el rol predeterminado (Usuario)
        var rolUsuario = _context.Roles.FirstOrDefault(r => r.Nombre == "Usuario");
        if (rolUsuario == null)
        {
            return BadRequest("El rol predeterminado 'Usuario' no está configurado.");
        }

        // Hashear la contraseña
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(registroDto.Password);

        // Crear usuario
        var usuario = new Usuario
        {
            Nombre = registroDto.Nombre,
            Apellido = registroDto.Apellido,
            Email = registroDto.Email,
            PasswordHash = passwordHash,
            Nivel = 1,
            Puntos = 0,
            FechaRegistro = DateTime.Now,
            RolId = rolUsuario.RolId
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok("Usuario registrado exitosamente.");
    }

    // Inicio de Sesión
    [HttpPost("login")]
    public async Task<IActionResult> Login(UsuarioLoginDto loginDto)
    {
        // Buscar el usuario en la base de datos
        var usuario = await _context.Usuarios
            .Include(u => u.Rol) // Incluye el rol del usuario
            .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

        if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, usuario.PasswordHash))
        {
            return Unauthorized("Credenciales incorrectas.");
        }

        // Generar el token JWT
        var token = GenerarToken(usuario);

        return Ok(new
        {
            Token = token,
            Usuario = new
            {
                usuario.UsuarioId,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Email,
                Rol = usuario.Rol.Nombre // Devuelve el nombre del rol
            }
        });
    }

    // Método para generar un token JWT
    private string GenerarToken(Usuario usuario)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),          // Email del usuario
            new Claim("id", usuario.UsuarioId.ToString()),                   // ID del usuario
            new Claim(ClaimTypes.Role, usuario.Rol.Nombre)                   // Rol del usuario
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],                           // Emisor del token
            audience: _configuration["Jwt:Audience"],                       // Audiencia del token
            claims: claims,                                                 // Claims del token
            expires: DateTime.Now.AddHours(1),                              // Expiración del token
            signingCredentials: creds                                      // Credenciales para firmar el token
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpGet("buscar")]
    public async Task<IActionResult> BuscarCursos([FromQuery] string? titulo, [FromQuery] string? nivelDificultad)
    {
        var query = _context.Cursos.AsQueryable();

        if (!string.IsNullOrWhiteSpace(titulo))
        {
            query = query.Where(c => c.Titulo.Contains(titulo));
        }

        if (!string.IsNullOrWhiteSpace(nivelDificultad))
        {
            query = query.Where(c => c.NivelDificultad == nivelDificultad);
        }

        var cursos = await query
            .Select(c => new
            {
                c.CursoId,
                c.Titulo,
                c.Descripcion,
                c.NivelDificultad
            })
            .ToListAsync();

        return Ok(cursos);
    }


}
