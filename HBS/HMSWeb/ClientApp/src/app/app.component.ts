import { Component, OnInit } from '@angular/core';
import {RoomService} from './services/room.service';
import {IroomList} from './interfaces/iroom';
import {Subscription} from 'rxjs';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  sub!: Subscription;
  title = 'ClientApp';
  rooms :IroomList[]= [];
  constructor(private roomService:RoomService){

  }
  ngOnInit(){
    
      
  }
}
