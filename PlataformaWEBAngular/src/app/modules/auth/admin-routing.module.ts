import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../core/guards/auth.guard';
import { AdminDashboardComponent } from '../admin/pages/dashboard/admin-dashboard/admin-dashboard.component';
import { CursosPageComponent } from '../admin/pages/cursos/cursos-page/cursos-page.component';


const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    children: [
      { path: 'dashboard', component: AdminDashboardComponent },
      { path: 'cursos', component: CursosPageComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
