import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_service/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'The Dating App';
  user: any;
 

  constructor(private accountService: AccountService){
    
  }
  ngOnInit(): void {
   //this.getUser();
    this.setCurrentUser();
  
  }
  setCurrentUser(){
    const user: User=JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }
 /*list of user 
 getUser(){
  this.http.get('https://localhost:5001/api/user').
 subscribe(response =>{this.users = response; },
  error => { console.log(error)})}*/
}
