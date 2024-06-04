import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from '../Environment/Environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../Models/User';

@Injectable({
  providedIn: 'root'
})

export class UserService {
  baseUrl: string = environment.apiUrl + "User";
  private id$ = new BehaviorSubject<number>(0);
  constructor(private http:HttpClient) { }

  

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl);
}
/*
  deleteUser(userId:number): Observable<User>{
    return this.http.delete<User>(`${this.baseUrl}/${userId}`)
}
*/
}
