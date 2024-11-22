import api from "../api"; // Axios instance
import { Curso } from "../types/Curso";


// Fetch all courses
export const getCursos = async () => {
  const response = await api.get("/Cursos");
  console.log("Cursos recibidos:", response.data); // Log para depuración
  return response.data;
};


// Add a new course
export const addCurso = async (curso: Curso): Promise<Curso> => {
  const response = await api.post<Curso>("/Cursos", curso);
  return response.data;
};

// Update a course
export const updateCurso = async (
  cursoId: number,
  updatedCurso: Curso
): Promise<Curso> => {
  const response = await api.put<Curso>(`/Cursos/${cursoId}`, updatedCurso);
  return response.data;
};

// Delete a course
export const deleteCurso = async (cursoId: number): Promise<void> => {
  await api.delete(`/Cursos/${cursoId}`);
};

export default {
  getCursos,
  addCurso,
  updateCurso,
  deleteCurso,
};
