import { Navigate } from "react-router-dom";
import authService from "../services/authService";

interface AdminRouteProps {
  children: React.ReactNode;
}

const AdminRoute: React.FC<AdminRouteProps> = ({ children }) => {
  const isAuthenticated = authService.isAuthenticated();
  const role = authService.getUserRole();

  return isAuthenticated && role === "Administrador" ? (
    <>{children}</>
  ) : (
    <Navigate to="/login" />
  );
};

export default AdminRoute;
