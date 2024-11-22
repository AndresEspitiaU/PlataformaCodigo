import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { FormsModule } from '@angular/forms';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, NgIf, RouterLink],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  nombre: string = '';
  apellido: string = '';
  email: string = '';
  password: string = '';
  error: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  onRegister(): void {
    this.authService
      .register(this.nombre, this.apellido, this.email, this.password)
      .subscribe({
        next: (response) => {
          console.log(response.mensaje); // Muestra el mensaje de éxito
          this.router.navigate(['/auth/login']); // Redirigir al login después del registro
        },
        error: (err) => {
          this.error = err.error.mensaje || 'Error al registrarse';
          console.error(err);
        },
      });
  }

}
