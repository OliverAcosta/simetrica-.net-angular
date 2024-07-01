import { HttpInterceptorFn } from '@angular/common/http';
import { environment } from './commons';

export const Interceptor: HttpInterceptorFn = (req, next) => {
  
  // Clone the request and add the authorization header
  const authReq = req.clone({
    headers: req.headers.set(
      "Authorization", `Bearer ${environment.userVariable.Token}`).
      set('Content-Type', 'application/json')
    
  });

  // Pass the cloned request with the updated header to the next handler
  return next(authReq);
};