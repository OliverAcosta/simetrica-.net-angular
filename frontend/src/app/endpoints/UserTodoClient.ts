import { HttpClient, HttpHeaders } from '@angular/common/http'
import { requestResult } from './requestResult'
import { Observable } from 'rxjs/internal/Observable';
import {catchError, of} from 'rxjs';
import { environment } from './commons';
import { LoginHelper } from './loginHelper';


export class UserTodosClient  {
  
  constructor(private http: HttpClient) {}
  private url:string = environment.baseUrl + "usertodos/";
  private login: LoginHelper = new LoginHelper();
  
 

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => { 
      return of(result as T);
    };
  }

  get(id:number):Observable<requestResult>{    
        return new Observable<requestResult>(subcriber =>{
        this.http.get<requestResult>(this.url + `get/${id}`)
        .pipe(
        catchError(this.handleError<requestResult>('get', new requestResult))
        ).subscribe((response)=>{
            subcriber.next(response);
            subcriber.complete();
        });
      });
  }

  paginate(page:number, pagesize:number):Observable<requestResult>{    
    return new Observable<requestResult>(subcriber =>{
    this.http.get<requestResult>(this.url + `paginate/${page}/${pagesize}`)
    .pipe(
    catchError(this.handleError<requestResult>('paginate', new requestResult))
    ).subscribe((response)=>{
        subcriber.next(response);
        subcriber.complete();
    });
    });
  }

  add(entity:any):Observable<requestResult>{    
    return new Observable<requestResult>(subcriber =>{
    this.http.post<any>(this.url + `add`, JSON.stringify(entity))
        .pipe(
        catchError(this.handleError<requestResult>('add', new requestResult))
        ).subscribe((response)=>{
            subcriber.next(response);
            subcriber.complete();
        });
    });
  }

  update(entity:any):Observable<requestResult>{    
    return new Observable<requestResult>(subcriber =>{
    this.http.post<any>(this.url + `update`, JSON.stringify(entity))
        .pipe(
        catchError(this.handleError<requestResult>('update', new requestResult))
        ).subscribe((response)=>{
            subcriber.next(response);
            subcriber.complete();
        });
    });
  }
 
}
