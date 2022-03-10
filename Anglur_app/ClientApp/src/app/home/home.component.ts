import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  registerMode = false;
  users: any;
  url: string = 'https://localhost:44326/api/users';
  constructor(/*private http: HttpClient*/) { }

  ngOnInit(): void {
   // this.getUsers();
  }

  //getUsers() {
  //  this.http.get(this.url).subscribe(users => this.users = users);     
  //}
  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

}
