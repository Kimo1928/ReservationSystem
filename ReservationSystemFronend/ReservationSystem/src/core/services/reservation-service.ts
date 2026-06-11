import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { enviorment } from '../../enviroments/enviroment.development';

@Injectable({
  providedIn: 'root',
})
export class ReservationService {
  private baseUrl = enviorment.apiUrl 
  private http = inject(HttpClient);



  public addReservation(reservation:any){
  
    return this.http.post(`${this.baseUrl}reservation/AddReservation`,reservation);

  }


  public getAvaliavleTimeSlots(presenterId:number,topicId:number,investorId:number){
    return this.http.get(`${this.baseUrl}reservation/GetAvaliableRooms?topicId=${topicId}&investorId=${investorId}&presenterId=${presenterId}&`);
  }
}
