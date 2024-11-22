import api from "../api"; // Axios instance
import { Usuario } from "../types/user";

// Fetch all users
export const getUsuarios = async (): Promise<Usuario[]> => {
  const response = await api.get<Usuario[]>("/Usuarios");
  return response.data;
};

// Add a new user
export const addUsuario = async (user: Usuario): Promise<Usuario> => {
  const response = await api.post<Usuario>("/Usuarios", user);
  return response.data;
};

// Update an existing user
export const updateUsuario = async (
  userId: number,
  updatedUser: Usuario
): Promise<Usuario> => {
  const response = await api.put<Usuario>(`/Usuarios/${userId}`, updatedUser);
  return response.data;
};

// Delete a user
export const deleteUsuario = async (userId: number): Promise<void> => {
  await api.delete(`/Usuarios/${userId}`);
};

export default {
  getUsuarios,
  addUsuario,
  updateUsuario,
  deleteUsuario,
};
