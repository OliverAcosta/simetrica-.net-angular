import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';

export const routes: Routes = [
    { path: 'login',title:"LogIn Page", component: LoginComponent },
    { path: 'dashboard',title:"Dashboard", component: DashboardComponent }
];
