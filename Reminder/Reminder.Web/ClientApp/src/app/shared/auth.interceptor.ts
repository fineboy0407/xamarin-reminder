import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { AuthService } from '../auth/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (this.authService.getAuthorizationHeaderValue() != null) {
      const copiedReq = req.clone({
        headers: req.headers.append
          ('Authorization', this.authService.getAuthorizationHeaderValue())
      });
      return next.handle(copiedReq);
    }
    return next.handle(req);
  }
}
