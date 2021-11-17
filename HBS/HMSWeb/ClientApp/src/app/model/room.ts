import { Injectable } from "@angular/core";

@Injectable()
export class Room{
    constructor(){
        this.roomNo="";
        this.roomTypeId=1;
    }
    roomNo:string;
    roomTypeId:number;
}