import { Component, OnInit,OnDestroy } from '@angular/core';
import {RoomService} from '../../services/room.service'
import {IroomList} from '../../interfaces/iroom';
import {Subscription} from 'rxjs';
import { Subject } from 'rxjs';
import { DataTablesModule } from 'angular-datatables';
import { Router } from '@angular/router';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.css']
})
export class RoomListComponent implements OnInit,OnDestroy {
  
  sub!: Subscription;
  title = 'ClientApp';
  rooms :IroomList[]= [];
  dtTrigger: Subject<any> = new Subject<any>();
  constructor(private roomService:RoomService,private router: Router){

  }
  ngOnInit(){
    this.roomService.getRooms().subscribe(response => {
     console.log(response) ;
     this.rooms=response;
      });
}
ngOnDestroy(){
  
}
addRoom() {
  this.router.navigate(['/createtoom']);
}

}
