import { Component } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { AccountClient } from '../endpoints/AccountClient';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Router, RouterModule, Routes } from '@angular/router';
import { routes } from '../app.routes';
import { environment } from '../endpoints/commons';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,MatFormFieldModule, MatButtonModule, MatInputModule,
     FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  router: Router = new Router()
  constructor(private http: HttpClient){}
  private account:AccountClient = new AccountClient(this.http);
  protected user:string = "";
  protected pass:string = ""; 
  

  check()
  {
    if(this.user.length < 3 || this.pass.length < 3)
      return false;
    return true;
  }
  login() {
      if(this.check())
      {
        this.account.Login(this.user, this.pass).subscribe((Response)=>{
          this.router.navigate(['/tareas']);
        });
      }
      
  }

}
