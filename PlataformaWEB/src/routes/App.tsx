import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from "../components/Auth/Login";
import Register from "../components/Auth/Register";
import Home from "../components/Home/Home";
import ProtectedRoute from "../components/Auth/ProtectedRoute";
import CursosPage from "../pages/Admin/CursosPage";
import AdminDashboard from "../pages/Admin/AdminDashboard";
import AdminRoute from "./AdminRoute";
import AdminLayout from "../components/Layout/AdminLayout";
import UserManagement from "../types/UserManagement";

function App() {
  return (
    <Router>
      <Routes>
        {/* Rutas Públicas */}
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />

        {/* Ruta Protegida para Usuarios */}
        <Route
          path="/home"
          element={
            <ProtectedRoute>
              <Home />
            </ProtectedRoute>
          }
        />

        {/* Rutas Protegidas para Administradores */}
        <Route
          path="/admin"
          element={
            <AdminRoute>
              <AdminLayout />
            </AdminRoute>
          }
        >
          {/* Rutas hijas de administrador */}
          <Route index element={<AdminDashboard />} /> {/* Vista principal */}
          <Route path="cursos" element={<CursosPage />} />
          <Route path="usuarios" element={<UserManagement />} />
        </Route>

        {/* Redirección por defecto */}
        <Route path="*" element={<Login />} />
      </Routes>
    </Router>
  );
}

export default App;
