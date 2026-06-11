import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { enviorment } from '../../enviroments/enviroment.development';
import { User, UserDto } from '../../models/User';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private baseUrl = enviorment.apiUrl 
  private http = inject(HttpClient);



  public addUser(user:UserDto){
 
    return this.http.post(`${this.baseUrl}user/CreateUser`,user);

  }

  public getAllInvestors(){
    return this.http.get<User>(`${this.baseUrl}user/GettingAllInvestors`);
  }

  public getAllPresenters(){
    return this.http.get<User>(`${this.baseUrl}user/GettingAllPresenters`);
  }

  public getMachingPresenters(topicId:number,investorId:number){
    return this.http.get<User>(`${this.baseUrl}user/GetMatchingPresenter?topic=${topicId}&investor=${investorId}`);
  }
}
