import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter, RouterModule } from '@angular/router';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { importProvidersFrom } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; // Importar FormsModule
import { routes } from './app.routes';
import { AuthInterceptor } from './core/interceptors/auth.interceptor'; // Interceptor personalizado para Auth

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }), // Mejora de rendimiento de zona
    provideRouter(routes), // Configuración de rutas
    provideClientHydration(withEventReplay()), // Hidratar eventos en SSR
    importProvidersFrom(HttpClientModule), // Importar HttpClientModule para solicitudes HTTP
    importProvidersFrom(FormsModule), // Importar FormsModule para usar ngModel
    importProvidersFrom(RouterModule),
    {
      provide: HTTP_INTERCEPTORS, // Proveedor para interceptores HTTP
      useClass: AuthInterceptor, // Interceptor personalizado
      multi: true,
    },
  ],
};
