import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { jwtDecode } from 'jwt-decode'; // jwtDecode sin llaves
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly TOKEN_KEY = 'token';
  private readonly API_URL = `${environment.apiUrl}/Auth`; // Usa environment.apiUrl

  constructor(private http: HttpClient) {}

  // Método de login
  login(email: string, password: string): Observable<any> {
    console.log('Enviando solicitud de login...');
    return this.http.post(`${environment.apiUrl}/Auth/login`, { email, password });
  }


  // Método de registro
  register(nombre: string, apellido: string, email: string, password: string): Observable<any> {
    return this.http.post(`${this.API_URL}/registro`, {
      nombre,
      apellido,
      email,
      password,
    });
  }

  // Método para guardar el token
  setToken(token: string): void {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  // Obtener token del almacenamiento local
  getToken(): string | null {
    if (typeof window !== 'undefined' && window.localStorage) {
      return localStorage.getItem(this.TOKEN_KEY);
    }
    return null;
  }


  // Obtener el rol del usuario desde el token
  getUserRole(): string | null {
    const token = this.getToken();
    if (token) {
      try {
        const decodedToken: any = JSON.parse(atob(token.split('.')[1])); // Decodifica el token
        console.log('Token decodificado:', decodedToken); // Imprime el token decodificado
        return decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] || null; // Claim del rol
      } catch (err) {
        console.error('Error al decodificar el token:', err);
        return null;
      }
    }
    return null;
  }




  // Logout
  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
  }
}
