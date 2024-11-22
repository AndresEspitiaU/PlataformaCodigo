import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { FormsModule } from '@angular/forms';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, RouterLink, NgIf],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  error: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  onLogin(): void {
    console.log('Enviando solicitud de login...');
    this.authService.login(this.email, this.password).subscribe({
      next: (response) => {
        this.authService.setToken(response.token); // Guarda el token
        console.log('Token recibido:', response.token);

        const role = this.authService.getUserRole(); // Obtén el rol del usuario
        console.log('Rol del usuario:', role);

        if (role === 'Administrador') {
          this.router.navigate(['/admin/dashboard']); // Redirige al dashboard de administrador
        } else if (role === 'Usuario') {
          this.router.navigate(['/home']); // Redirige al home para usuarios regulares
        } else {
          console.error('Rol desconocido:', role);
          this.error = 'Rol desconocido, no se puede redirigir.';
        }
      },
      error: (err) => {
        console.error('Error en el login:', err);
        this.error = 'Credenciales incorrectas';
      },
    });
  }


}
