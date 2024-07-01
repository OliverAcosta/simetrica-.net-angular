import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserTodosComponent } from './user-todos/user-todos.component';

export const routes: Routes = [
    { path: 'login',title:"LogIn Page", component: LoginComponent },
    { path: 'dashboard',title:"Dashboard", component: DashboardComponent },
    { path: 'tareas',title:"Tareas de usuario", component: UserTodosComponent }
];
