import { Injectable } from "@angular/core";

@Injectable()
export class UserModel{
    constructor(){
        this.username="";
        this.password="";
        this.email="";
    }
    username: string;
    password:string;
    email: string;
    token?: string;
}