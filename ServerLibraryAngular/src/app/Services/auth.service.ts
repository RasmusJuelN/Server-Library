import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../Environment/Environment';

@Injectable({
    providedIn: 'root'
  })

  export class AuthService {

    baseUrl: string = environment.apiUrl + "Authentication/";
    constructor(private http:HttpClient){}


    login(loginRequest: any) : Observable<any> {
        return this.http.post<any>(`${this.baseUrl}authenticate`, loginRequest);
      }
  }
  