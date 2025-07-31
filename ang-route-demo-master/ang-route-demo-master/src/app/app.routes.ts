import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { NewOrderComponent } from './new-order/new-order.component';

export const routes: Routes = [
    {path:"login",component:LoginComponent},
    {path:"new-order",component:NewOrderComponent},  
];
 