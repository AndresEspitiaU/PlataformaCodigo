import { Link, useNavigate } from "react-router-dom";

const AdminHeader = () => {
  const navigate = useNavigate();

  const handleLogout = () => {
    localStorage.clear();
    navigate("/login");
  };

  return (
    <nav className="bg-gray-800 p-4 text-white flex justify-between">
      <div>
        <Link to="/admin/cursos" className="mr-4 hover:underline">
          Cursos
        </Link>
        <Link to="/admin/lecciones" className="hover:underline">
          Lecciones
        </Link>
      </div>
      <button onClick={handleLogout} className="bg-red-500 px-4 py-2 rounded hover:bg-red-600">
        Cerrar Sesión
      </button>
    </nav>
  );
};

export default AdminHeader;
