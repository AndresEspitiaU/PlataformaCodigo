import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { jwtDecode } from "jwt-decode";

interface DecodedToken {
  nombre: string;
  rol: string;
  email: string;
}

const Home = () => {
  const [userName, setUserName] = useState<string | null>(null);
  const navigate = useNavigate();

  useEffect(() => {
    const token = localStorage.getItem("token");

    if (!token) {
      navigate("/login"); // Redirige al login si no hay token
    } else {
      try {
        const decodedToken: DecodedToken = jwtDecode<DecodedToken>(token);
        setUserName(decodedToken.nombre || "Usuario");
      } catch (error) {
        console.error("Error al decodificar el token:", error);
        navigate("/login");
      }
    }
  }, [navigate]);

  const handleLogout = () => {
    localStorage.removeItem("token");
    navigate("/login");
  };

  return (
    <div className="min-h-screen flex flex-col items-center justify-center bg-gradient-to-br from-gray-100 to-gray-200">
      <div className="bg-white shadow-lg rounded-lg p-8 w-full max-w-lg text-center">
        <h1 className="text-3xl font-bold text-gray-800 mb-4">
          Bienvenido, {userName}!
        </h1>
        <p className="text-gray-600 mb-6">
          Has iniciado sesión correctamente. Disfruta de la plataforma.
        </p>
        <button
          onClick={handleLogout}
          className="bg-red-500 text-white px-6 py-2 rounded-lg font-semibold hover:bg-red-600 transition duration-300"
        >
          Cerrar Sesión
        </button>
      </div>
    </div>
  );
};

export default Home;
