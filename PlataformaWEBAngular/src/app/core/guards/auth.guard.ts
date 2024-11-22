import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const token = this.authService.getToken(); // Obtiene el token
    const role = this.authService.getUserRole(); // Obtiene el rol del usuario

    if (!token || !role) {
      // Si no está autenticado, redirige al login
      this.router.navigate(['/auth/login']);
      return false;
    }

    // Verifica el acceso a rutas específicas según el rol
    const url = state.url;

    if (role === 'Administrador' && url.startsWith('/admin')) {
      return true; // Admin puede acceder a rutas que comienzan con /admin
    } else if (role === 'Usuario' && url.startsWith('/home')) {
      return true; // Usuario puede acceder a rutas que comienzan con /home
    }

    // Si no tiene acceso, redirige a una página predeterminada o al login
    this.router.navigate(['/auth/login']);
    return false;
  }
}
