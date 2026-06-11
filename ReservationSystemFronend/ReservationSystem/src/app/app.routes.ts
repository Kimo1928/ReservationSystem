import { Routes } from '@angular/router';
import { HotelComponent } from '../features/hotel/hotel';
import { Home } from '../features/home/home';
import { InvestorComponent } from '../features/investor-component/investor-component';
import { PresenterComponent } from '../features/presenter-component/presenter-component';
import { ReservationComponent } from '../features/reservation-component/reservation-component';

export const routes: Routes = [

    {path:'',component:Home}
    ,
    {path:'hotels',component:HotelComponent} ,
    {path:'investors',component:InvestorComponent} , 
    {path:'presenters',component:PresenterComponent} ,   
    {path:'reservations',component:ReservationComponent} ,
];
