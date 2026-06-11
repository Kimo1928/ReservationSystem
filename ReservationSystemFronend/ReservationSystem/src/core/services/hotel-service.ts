import { inject, Injectable } from '@angular/core';
import { enviorment } from '../../enviroments/enviroment.development';
import { HttpClient } from '@angular/common/http';
import { Hotel } from '../../models/hotel';

@Injectable({
  providedIn: 'root',
})
export class HotelService {

  private baseUrl = enviorment.apiUrl 
  private http = inject(HttpClient);

  public addHotel(hotel:Hotel){
    
    return this.http.post(`${this.baseUrl}hotel/CreateHotel`,hotel);
  } 

  public getHotels(){
    return this.http.get<Hotel[]>(`${this.baseUrl}hotel/GetAllHotels`);
  }

}
