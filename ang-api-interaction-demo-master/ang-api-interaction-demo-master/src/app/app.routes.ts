import { Routes } from '@angular/router';
import { ShowOrderComponent } from './show-order/show-order.component';

export const routes: Routes = [
    {path:'login', loadComponent: () => import('./login/login.component').then(m => m.LoginComponent)},
    {path:'show-order',component: ShowOrderComponent},
    {path:'add-order',loadComponent:()=> import('./add-order/add-order.component').then(m=>m.AddOrderComponent)}
];
