import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ViewSolderingComponent } from './view-soldering/view-soldering.component';
import { AddOrderComponent } from './add-order/add-order.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,ViewSolderingComponent,AddOrderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'WheelFactory';
}
