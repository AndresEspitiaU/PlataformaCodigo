import { useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../../api";

const Register = () => {
  const [nombre, setNombre] = useState("");
  const [apellido, setApellido] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");
  const navigate = useNavigate();

  const handleRegister = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const response = await api.post("/Auth/registro", {
        nombre,
        apellido,
        email,
        password,
      });

      // Guarda el token en localStorage si la API lo devuelve
      localStorage.setItem("token", response.data.token);

      // Mostrar éxito y redirigir al Home
      setSuccess("Registro exitoso. Redirigiendo...");
      setError("");

      // Redirigir al Home después de un breve retraso
      setTimeout(() => {
        navigate("/home");
      }, 1000);
    } catch (err) {
      console.error("Error en el registro:", err);
      setError("Ocurrió un error al registrarte. Inténtalo nuevamente.");
      setSuccess("");
    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-gradient-to-br from-green-100 to-green-200">
      <div className="bg-white shadow-lg rounded-lg p-8 w-full max-w-md">
        <h2 className="text-2xl font-bold text-center text-green-600 mb-4">
          Registro
        </h2>
        {error && (
          <p className="text-red-500 text-sm text-center mb-4">{error}</p>
        )}
        {success && (
          <p className="text-green-500 text-sm text-center mb-4">{success}</p>
        )}
        <form onSubmit={handleRegister}>
          <div className="mb-4">
            <label className="block text-gray-700 mb-2">Nombre</label>
            <input
              type="text"
              value={nombre}
              onChange={(e) => setNombre(e.target.value)}
              className="w-full border rounded-lg px-4 py-2 focus:outline-none focus:ring focus:ring-green-300"
              placeholder="Escribe tu nombre"
              required
            />
          </div>
          <div className="mb-4">
            <label className="block text-gray-700 mb-2">Apellido</label>
            <input
              type="text"
              value={apellido}
              onChange={(e) => setApellido(e.target.value)}
              className="w-full border rounded-lg px-4 py-2 focus:outline-none focus:ring focus:ring-green-300"
              placeholder="Escribe tu apellido"
              required
            />
          </div>
          <div className="mb-4">
            <label className="block text-gray-700 mb-2">Correo Electrónico</label>
            <input
              type="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              className="w-full border rounded-lg px-4 py-2 focus:outline-none focus:ring focus:ring-green-300"
              placeholder="Escribe tu correo"
              required
            />
          </div>
          <div className="mb-6">
            <label className="block text-gray-700 mb-2">Contraseña</label>
            <input
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="w-full border rounded-lg px-4 py-2 focus:outline-none focus:ring focus:ring-green-300"
              placeholder="Escribe tu contraseña"
              required
            />
          </div>
          <button
            type="submit"
            className="w-full bg-green-500 text-white py-2 rounded-lg hover:bg-green-600 transition duration-300"
          >
            Registrarse
          </button>
        </form>
        <p className="text-center text-gray-600 mt-4">
          ¿Ya tienes una cuenta?{" "}
          <a href="/login" className="text-green-500 hover:underline">
            Inicia sesión
          </a>
        </p>
      </div>
    </div>
  );
};

export default Register;
