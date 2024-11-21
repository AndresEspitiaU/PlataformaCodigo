
SELECT * FROM Roles;
SELECT * FROM Usuarios;
SELECT * FROM Cursos;

SELECT u.UsuarioId, u.Nombre, u.Apellido, u.Email, u.RolId, r.Nombre AS Rol
FROM Usuarios u
LEFT JOIN Roles r ON u.RolId = r.RolId
WHERE u.UsuarioId = 3;
