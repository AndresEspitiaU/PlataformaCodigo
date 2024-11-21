import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5206/api", // Cambia la URL base según tu configuración de API
  headers: {
    "Content-Type": "application/json",
  },
});

export default api;
