import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login/login.component';
import {RoomListComponent} from './room/room-list/room-list.component';
import { CreateRoomComponent } from './room/create-room/create-room.component';

const routes: Routes = [
  { path: '', component:LoginComponent,pathMatch:'full' },
  { path: 'roomlist', component: RoomListComponent },
  { path: 'createroom', component: CreateRoomComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
