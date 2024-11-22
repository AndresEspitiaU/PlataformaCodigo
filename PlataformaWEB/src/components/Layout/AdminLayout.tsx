import { NavLink, Outlet } from "react-router-dom";

const AdminLayout = () => {
  return (
    <div className="min-h-screen flex flex-col">
      {/* Header */}
      <header className="bg-blue-600 text-white p-4">
        <nav className="container mx-auto flex justify-between">
          <h1 className="text-lg font-bold">Panel de Administración</h1>
          <div>
            <NavLink
              to="/admin"
              className={({ isActive }) =>
                isActive ? "underline font-bold mx-2" : "mx-2"
              }
            >
              Dashboard
            </NavLink>
            <NavLink
              to="/admin/cursos"
              className={({ isActive }) =>
                isActive ? "underline font-bold mx-2" : "mx-2"
              }
            >
              Cursos
            </NavLink>
            <NavLink
              to="/admin/usuarios"
              className={({ isActive }) =>
                isActive ? "underline font-bold mx-2" : "mx-2"
              }
            >
              Usuarios
            </NavLink>
          </div>
        </nav>
      </header>

      {/* Contenido dinámico */}
      <main className="container mx-auto p-4">
        <Outlet /> {/* Renders the current route */}
      </main>
    </div>
  );
};

export default AdminLayout;
