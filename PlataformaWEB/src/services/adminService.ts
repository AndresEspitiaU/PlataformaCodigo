import api from "../api"; // Axios instance
import { Usuario } from "../types/user"; // Assuming `Usuario` is a type representing a user

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

// Fetch all courses
export const getCursos = async (): Promise<unknown[]> => {
  const response = await api.get<unknown[]>("/Cursos");
  return response.data;
};

// Add a new course
export const addCurso = async (curso: unknown): Promise<unknown> => {
  const response = await api.post<unknown>("/Cursos", curso);
  return response.data;
};

// Update a course
export const updateCurso = async (cursoId: number, updatedCurso: unknown): Promise<unknown> => {
  const response = await api.put<unknown>(`/Cursos/${cursoId}`, updatedCurso);
  return response.data;
};

// Delete a course
export const deleteCurso = async (cursoId: number): Promise<void> => {
  await api.delete(`/Cursos/${cursoId}`);
};

// Export all functions as named exports
const adminService = {
  getUsuarios,
  addUsuario,
  updateUsuario,
  deleteUsuario,
  getCursos,
  addCurso,
  updateCurso,
  deleteCurso,
};

export default adminService;
