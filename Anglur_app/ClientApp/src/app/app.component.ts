
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'Dating App';
  users: any;
  url: string = 'https://localhost:44326/api/users';

  constructor(private http: HttpClient) { }
  ngOnInit() {
    // this.service.getAllBooks();
    this.getUsers();
  }


  getUsers() {
    this.http.get(this.url).subscribe(response => { this.users = response },
      error => { console.log(error) })
      
   
  }
}
