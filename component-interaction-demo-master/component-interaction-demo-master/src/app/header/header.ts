import { Component, signal ,effect} from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { LoginService } from '../services/login';
 

@Component({
  selector: 'app-header',
  imports: [MatToolbarModule],
  templateUrl: './header.html',
  styleUrl: './header.css'
})
export class Header {
title:string=''
user:string=''
constructor(private us:LoginService){
  effect(() => {
      this.title = this.us.getUser();
    });
}

 

}
