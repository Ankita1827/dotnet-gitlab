import { Routes } from '@angular/router';
import { Login } from './components/login/login';
import { Register } from './components/register/register';
import { ShowDetails } from './components/show-details/show-details';
import { ForgotPassword } from './components/forgot-password/forgot-password';
import { Navbar } from './components/navbar/navbar';
import { Footer } from './components/footer/footer';
import { Home } from './components/home/home';
import { About } from './components/about/about';
import { NewVenue } from './components/new-venue/new-venue';
import { ShowVenue } from './components/show-venue/show-venue';
import { EditVenue } from './components/edit-venue/edit-venue';
import { DeleteVenue } from './components/delete-venue/delete-venue';
import { BookingManagementComponent } from './components/booking-management/booking-management.component';
import { ViewSlots } from './components/view-slots/view-slots';
import { UserBooking } from './components/user-booking/user-booking';
import { Payment } from './components/payment/payment';
import { unauthorizedGuard } from './guards/unauthorized-guard';

export const routes: Routes = [
    {path:'navbar', component:Navbar},
    {path:'login', component:Login},
    {path:'register',component:Register},
    {path:'show-details', component:ShowDetails},
    {path:'forgot-password', component:ForgotPassword},
    {path:'add-venue',component:NewVenue,canActivate:[unauthorizedGuard]},
    {path:'show-venues',component:ShowVenue},
    {path:'edit-venue/:id',component:EditVenue},
    {path:'delete-venue/:id',component:DeleteVenue},
    {path:'slot-management/:venueid',component:BookingManagementComponent},
    {path:'view-slots',component:ViewSlots},
    {path:'user-booking/:id',component:UserBooking},
    {path:'payment/:rateValue', component:Payment},
    {path:'about',component:About},
    {path:'home', component:Home},
    {path:'footer', component:Footer},
    {path:'',component:Home}
    // {path:'register', loadComponent: () => import('./register/register').then(m => m.Register)},
    // {path:'', redirectTo:'login', pathMatch:'full'},
];
