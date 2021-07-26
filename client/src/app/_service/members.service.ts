import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { members } from '../_models/members';
 
@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = 'https://localhost:5001/api/';
 
  httpOptions = {
    headers: new HttpHeaders({
      Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
    })
  };
  
  constructor(private http: HttpClient) { }
 
  getMembers() {
    return this.http.get<members[]>(this.baseUrl + 'user', this.httpOptions);
  }
  getMember(username: string) {
    return this.http.get<members>(this.baseUrl + 'user/' + username, this.httpOptions);
  }
}
 