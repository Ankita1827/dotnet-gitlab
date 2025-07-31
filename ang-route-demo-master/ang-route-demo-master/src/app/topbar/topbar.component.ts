import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-topbar',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './topbar.component.html',
  styleUrl: './topbar.component.css'
})
export class TopbarComponent {
 constructor(private router:Router){}
LoginHandler(){
 this.router.navigate(['/login'])
}
}
//new TopbarComponent(new Router());
