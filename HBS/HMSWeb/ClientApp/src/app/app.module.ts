import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RoomtypeListComponent } from './room/roomtype-list/roomtype-list.component';
import { RoomListComponent } from './room/room-list/room-list.component';
import { DataTablesModule } from 'angular-datatables';
import { CreateRoomComponent } from './room/create-room/create-room.component';
import { FormsModule ,ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login/login.component';
import { AuthenticationService } from './services/auth.service';
import { JWTInterceptor } from './services/JwtInterceptor';
import { SocialLoginModule, SocialAuthServiceConfig } from 'angularx-social-login';
import { GoogleLoginProvider } from 'angularx-social-login';



@NgModule({
  declarations: [
    AppComponent,
    RoomtypeListComponent,
    RoomListComponent,
    CreateRoomComponent,
    LoginComponent,
    
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    DataTablesModule,
    FormsModule,
    ReactiveFormsModule ,
    SocialLoginModule
    
  ],
  providers: [

    {provide:HTTP_INTERCEPTORS,useClass:JWTInterceptor,multi:true} ,
    AuthenticationService,
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              '409760573256-msuu3qvr07jhhajub84qlqu24u6onu8g.apps.googleusercontent.com'
            )
          },
        ],
      } as SocialAuthServiceConfig
    }
   
    
  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { 
  private REST_API_SERVER = "http://localhost:44345";
}
