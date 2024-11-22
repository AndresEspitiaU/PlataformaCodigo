import axios from "axios";

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL, // URL base definida en .env
});

// Interceptor para agregar el token a todas las solicitudes
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem("token");
    if (token) {
      console.log("Enviando token:", token); // Depuración
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);


export default api;
