import { jwtDecode } from "jwt-decode";

interface DecodedToken {
  rol: string;
  exp: number; // Expiración del token
  [key: string]: unknown; // Otros datos opcionales
}



const getToken = (): string | null => {
  const token = localStorage.getItem("token");
  console.log("Token actual:", token); // Verifica si el token es correcto
  return token;
};


const getDecodedToken = (): DecodedToken | null => {
  const token = getToken();
  if (!token) return null;

  try {
    const decoded = jwtDecode(token) as DecodedToken;
    console.log("Token decodificado:", decoded); // Verifica la estructura aquí
    return decoded;
  } catch (err) {
    console.error("Error al decodificar el token:", err);
    return null;
  }
};


const getUserRole = (): string | null => {
  const decodedToken = getDecodedToken();
  console.log("Token decodificado en getUserRole:", decodedToken);
  if (!decodedToken) return null;

  // Busca en las claves posibles
  const role =
    decodedToken.rol ||
    decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
  
  return typeof role === "string" ? role : null; // Asegúrate de que sea una cadena
};



const isAuthenticated = (): boolean => {
  const token = getToken();
  if (!token) return false;

  const decodedToken = getDecodedToken();
  if (!decodedToken) return false;

  // Verificar si el token ha expirado
  const currentTime = Math.floor(Date.now() / 1000);
  return decodedToken.exp > currentTime;
};

const authService = {
  getToken,
  getDecodedToken,
  getUserRole,
  isAuthenticated,
};

export default authService;
