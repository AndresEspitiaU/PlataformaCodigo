import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../../core/services/auth.service';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  userRole: string | null = '';
  userName: string | null = '';

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.userRole = this.authService.getUserRole();
    this.userName = this.authService.getToken() ? 'Usuario Logeado' : null; // Cambia según tu lógica de backend
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
