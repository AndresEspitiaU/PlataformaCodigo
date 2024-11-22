import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../../core/services/auth.service';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [NgIf],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  userRole: string | null = null;
  showHeader = false; // Variable para controlar la visibilidad del header

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.userRole = this.authService.getUserRole(); // Obtiene el rol del usuario

    // Suscribirse a los eventos de navegación
    this.router.events.subscribe(() => {
      // Verificar si la ruta actual es una ruta de autenticación
      this.showHeader = !this.router.url.includes('/auth');
    });
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/auth/login']); // Redirige al login
  }
}
