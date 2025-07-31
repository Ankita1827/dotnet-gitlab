import { Routes } from '@angular/router';
import { ShowOrder } from './show-order/show-order';
import { Component } from '@angular/core';
import { Home } from './home/home';
import { NewOrder } from './new-order/new-order';
import { EditOrder } from './edit-order/edit-order';

export const routes: Routes = [
    {path:'show-order',component:ShowOrder},
    {path:'edit-order/:id',component:EditOrder},
    {path:"new-order",loadComponent: () => import('./new-order/new-order').then(m => m.NewOrder)},
    {path:"",component:Home},
];
