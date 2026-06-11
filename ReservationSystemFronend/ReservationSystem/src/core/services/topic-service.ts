import { inject, Injectable } from '@angular/core';
import { enviorment } from '../../enviroments/enviroment.development';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TopicService {
  private baseUrl = enviorment.apiUrl 
  private http = inject(HttpClient);


  public getAllTopics(){
    return this.http.get(`${this.baseUrl}topic/GettingAllTopics`);
  }

}
