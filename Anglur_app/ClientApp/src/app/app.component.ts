
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from 'oidc-client';
import { AccountService } from './_Services/Account.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'Dating App';
  users: any;
  url: string = 'https://localhost:44326/api/users';

  constructor( private accountService: AccountService) { }
  ngOnInit() {
    // this.service.getAllBooks();
    
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    //if (user) {
      this.accountService.setCurrentUser(user);
    //  this.presence.createHubConnection(user);
    //}

  }

 
}
