import { useState, useEffect } from "react";
import cursoService from "../../services/cursoService";
import { Curso } from "../../types/Curso";


const CursosPage = () => {
  const [cursos, setCursos] = useState<Curso[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  const loadCursos = async () => {
    try {
      setLoading(true);
      const data = await cursoService.getCursos();
      console.log("Cursos recibidos:", data); // Agrega este log
      if (Array.isArray(data)) {
        setCursos(data);
      } else {
        throw new Error("La respuesta no es un arreglo.");
      }
    } catch (err) {
      setError("Error al cargar los cursos.");
      console.error("Error al cargar los cursos:", err); // Agrega este log
    } finally {
      setLoading(false);
    }
  };
  

  useEffect(() => {
    loadCursos();
  }, []);

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4">Gestión de Cursos</h1>

      {loading ? (
        <p>Cargando...</p>
      ) : error ? (
        <p className="text-red-500">{error}</p>
      ) : cursos.length === 0 ? (
        <p>No hay cursos disponibles.</p>
      ) : (
        <div>
          {cursos.map((curso) => (
            <div key={curso.cursoId} className="border p-4 rounded mb-4">
              <h2 className="font-bold">{curso.titulo}</h2>
              <p>{curso.descripcion}</p>
              <p className="text-gray-500">Duración: {curso.duracion} horas</p>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default CursosPage;
