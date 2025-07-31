import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  loggedUser = signal<string>('')
  getUser(){
    return this.loggedUser();
  }
  setUser(user:string){
    this.loggedUser.set(user);
  }
}
