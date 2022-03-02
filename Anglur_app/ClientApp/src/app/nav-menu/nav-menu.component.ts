import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_Services/Account.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit{
  model: any = {}
  loggedIn: boolean;

  constructor(private accountService: AccountService) { }
  ngOnInit(): void { }
  login() {
    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
      this.loggedIn = true;
    }, error => {
      console.log(error);
    })
  }

  logout() {
    this.loggedIn = false;
  }
}
