import { HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthenticationService } from "./auth.service";

@Injectable()
export class JWTInterceptor implements HttpInterceptor{
    constructor(private authenticationService: AuthenticationService){

    }
    intercept(request:HttpRequest<any>,next:HttpHandler){
        debugger;
       const currentUser = this.authenticationService.currentUserValue;
       const isLoggedIn = currentUser && currentUser.token;
       if (isLoggedIn) {
          request = request.clone({
            setHeaders: {
             Authorization: `Bearer ${currentUser.token}`
            }
          });
        }
    
        return next.handle(request);
    }
}