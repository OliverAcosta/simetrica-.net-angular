import { Component, Injectable, OnInit } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorIntl, MatPaginatorModule, PageEvent} from '@angular/material/paginator';
import { UserTodosClient } from '../endpoints/UserTodoClient';
import { HttpClient } from '@angular/common/http';
import { UserTodo } from '../endpoints/UserTodo';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { environment } from '../endpoints/commons';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-user-todos',
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule, MatFormFieldModule, MatButtonModule, MatInputModule,
    FormsModule, MatCheckboxModule],
  templateUrl: './user-todos.component.html',
  styleUrl: './user-todos.component.css'
})

export class UserTodosComponent implements OnInit {

  constructor(private http: HttpClient) {
      environment.userVariable.checkForLogin();
      
  }

  userClient:UserTodosClient = new UserTodosClient(this.http);
  paginator: PageEvent = new PageEvent();
  public displayedColumns: string[] = ['id', 'task', 'description', 'isDone'];
  dataSource:UserTodo[] = [];
  selection = new SelectionModel<UserTodosClient>(false, []);
  user:UserTodo = {
    id:0,
    task:"",
    description:"",
    isDone:false
  };
  
  editRow(data: UserTodo) {
      this.user = data;
  }
    

  ngOnInit()
  {
     this.paginator.pageIndex = 0;
     this.paginator.pageSize = 10;
     this.paginate();
  }
  paginate(){
    this.userClient.paginate(this.paginator.pageIndex, this.paginator.pageSize)
      .subscribe((subscriber)=>{
          if(subscriber.success)
          {
            this.dataSource = subscriber.result.datos;
            this.paginator.length = subscriber.result.total;
          }
      });
  }
  verificate()
  {
    if(this.user.id > 0)
      this.update();
    else
      this.add();
  }
  add()
  {
    if(this.verifyUser()){
      this.userClient.add(this.user).subscribe(subscription=>{
        if(subscription.success){
          this.clear();
          this.paginate();
          alert("Tarea se agrego correctamente");
        }
        else
          alert("Se produjo un error y no se puedo agregar la tarea")
      });
      
   }
  }

  update()
  {
    if(this.verifyUser()){
    this.userClient.update(this.user).subscribe(subscription=>{
      if(subscription.success)
        alert("Tarea se actualizo correctamente");
      else
        alert("Se produjo un error y no se puedo actualizar!")
    });
    this.clear();
    this.paginate();
  }
  }
  verifyUser()
  {
    console.log(this.user)
    if(this.user.task.length > 0 && this.user.description.length > 0)
      return true;
    return false;
  }
  clear()
  {
    this.user  = {
      id:0,
      task:"",
      description:"",
      isDone:false
    };
  }
}
