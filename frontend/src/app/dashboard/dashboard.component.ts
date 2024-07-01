import { Component } from '@angular/core';
import { environment } from '../endpoints/commons';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
 constructor()
 {
  environment.userVariable.checkForLogin();
 }
}
