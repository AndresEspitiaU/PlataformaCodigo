export interface Curso {
  cursoId: number;
  titulo: string;
  descripcion: string;
  imagen?: string;
  duracion: number;
  nivelDificultad?: string;
  activo: boolean;
  fechaCreacion: string;
  fechaActualizacion?: string;
}
