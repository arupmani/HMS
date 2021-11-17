import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map,tap} from 'rxjs/operators'
import { Observable } from 'rxjs';
import{IroomList }from '../interfaces/iroom'
import{IroomType }from '../interfaces/iroom-type'
import {environment} from '../../environments/environment'
import { Room } from '../model/room';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  private  roomSeriveURL=environment.baseUrl + 'api/v1/Room/';
  constructor(private httpclient: HttpClient) { }

   getRooms():Observable<IroomList[]> 
  {
    return this.httpclient.get<IroomList[]>(this.roomSeriveURL+'GetRooms')
.pipe(tap(data =>  console.log('Rooms: ', JSON.stringify(data))))|| []
  }
  getRoomTypes():Observable<IroomType[]> 
  {
    return this.httpclient.get<IroomType[]>(this.roomSeriveURL+'GetRoomTypes')
.pipe(tap(data =>  console.log('RoomTypes: ', JSON.stringify(data))))|| []
  }

  addRoom(room:Room): Observable<any> {
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(room);
    console.log(body)
    return this.httpclient.post(this.roomSeriveURL + 'AddRoom', body,{'headers':headers})
  }
  
  

}
