import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Login } from './login/login';
import { Header } from "./header/header";
import { Parent } from './parent/parent';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Login, Header,Parent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('mat-signal-demo');
}
