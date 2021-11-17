import { Component, OnInit,OnDestroy } from '@angular/core';
import {RoomService} from '../../services/room.service';
import{IroomList} from '../../interfaces/iroom'
import { HttpClient } from '@angular/common/http';
import {map,tap} from 'rxjs/operators';
import { IroomType } from 'src/app/interfaces/iroom-type';
import {Subscription} from 'rxjs';
import { Observable } from 'rxjs';
import { Room } from 'src/app/model/room';
import { NgForm } from '@angular/forms';



@Component({
  selector: 'app-create-room',
  templateUrl: './create-room.component.html',
  styleUrls: ['./create-room.component.css']
})

export class CreateRoomComponent implements OnInit {

 
  constructor(private httpclient: HttpClient,private roomService:RoomService) { }
  sub!: Subscription;
  title = 'ClientApp';
  roomTypes :IroomType[]= [];
  room:Room;

  ngOnInit(){
    this.room=new Room();
    this.roomService.getRoomTypes().subscribe(response => {
     console.log(response) ;
     this.roomTypes=response;
      });
}

addRoom(form:NgForm) {
  console.log(form)
  this.room.roomNo=form.value.roomNo;
  if(this.room.roomTypeId!=null)
  this.room.roomTypeId=parseInt(form.value.roomTypeId) ;
  this.roomService.addRoom(this.room).subscribe(response=>{
    console.log(response)
  })
}

}
