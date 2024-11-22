import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./shared/components/header/header/header.component";
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  isAuthRoute = false;

  constructor(private router: Router) {
    // Suscribirse a cambios de la ruta
    this.router.events.subscribe(() => {
      this.isAuthRoute = this.router.url.includes('/auth');
    });
  }
}
