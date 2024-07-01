import { HttpClient, HttpHeaders } from '@angular/common/http'
import { requestResult } from './requestResult'
import { Observable } from 'rxjs/internal/Observable';
import {catchError, of} from 'rxjs';
import { Injector, inject } from '@angular/core';
import { environment } from './commons';
import { LoginHelper } from './loginHelper';


export class AccountClient  {
  
  private url:string = environment.baseUrl + "account/";
  private login: LoginHelper = new LoginHelper();

  constructor(private http: HttpClient) 
  {  
    
  }
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => { 
      return of(result as T);
    };
  }

  Login(username:string, password:string):Observable<boolean>{

    let data = {"Username": username,"Password": password};
    
    return new Observable<boolean>(subcriber =>{
     this.http.post<requestResult>(this.url + "login", data)
    .pipe(
      catchError(this.handleError<requestResult>('login', new requestResult))
    ).subscribe((response)=>{
      if(response.success)
        {
          environment.userVariable.SaveTokenObj(response.result);
          console.log(response.result)
        }
      subcriber.next(response.success)
      subcriber.complete();
      
    });
  });
  
  }
  IsAuthenticated()
  {
    return new Observable<requestResult>(subcriber =>{
      this.http.get<requestResult>(this.url + "is-authenticated")
     .pipe(
       catchError(this.handleError<requestResult>('is-authenticated', new requestResult))
     ).subscribe((response)=>{
       subcriber.next(response)
       subcriber.complete();
     });
    });
  }
  RefreshToken(token:string):Observable<requestResult>
  {
    let data = {"Token":token};
    return new Observable<requestResult>(subcriber =>{
      this.http.post<requestResult>(this.url + "refresh-token", data)
     .pipe(
       catchError(this.handleError<requestResult>('refresh-token', new requestResult))
     ).subscribe((response)=>{
       subcriber.next(response)
       subcriber.complete();
     });
    });
  }
}
