import { Component, effect, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { LoginService } from '../services/login';


@Component({
  selector: 'app-login',
  imports: [MatButtonModule,FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  title:string=''
constructor(private ls:LoginService){
  
}
loginHandler(){
   this.ls.setUser(this.title)
}
}
