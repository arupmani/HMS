import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { UserModel } from "../model/user";
import { SocialAuthService } from "angularx-social-login";
import { GoogleLoginProvider } from "angularx-social-login";


@Injectable()

export class AuthenticationService {
    public currentUserSubject: BehaviorSubject<UserModel>;
    public currentUser: Observable<UserModel>;
     
    private  authServiceURL=environment.baseUrl + 'api/Token/';
    constructor(private httpclient: HttpClient, private _externalAuthService: SocialAuthService) {
        this.currentUserSubject = new BehaviorSubject<UserModel>(JSON.parse(localStorage.getItem('currentUser') || '{}'));
        this.currentUser = this.currentUserSubject.asObservable();
      }
      public get currentUserValue(): UserModel {
        return this.currentUserSubject.value;
      }
    
      login(user:UserModel): Observable<any> {
        const headers = { 'content-type': 'application/json'}  
        const body=JSON.stringify(user);
        console.log(body)
        return this.httpclient.post(this.authServiceURL + 'authentication', body,{'headers':headers})
      }

      public signInWithGoogle = ()=> {
        return this._externalAuthService.signIn(GoogleLoginProvider.PROVIDER_ID);
      }
      public signOutExternal = () => {
        this._externalAuthService.signOut();
      }
}