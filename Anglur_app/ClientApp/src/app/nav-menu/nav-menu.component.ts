import { Component, OnInit } from '@angular/core';
import { User } from 'oidc-client';
import { Observable } from 'rxjs';
import { AccountService } from '../_Services/Account.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit{
  model: any = {}
  currentUser$: Observable<User>;

  constructor(private accountService: AccountService) { }
  ngOnInit(): void {
    this.currentUser$=this.accountService.currentUser$;
  }
  login() {
    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
 
    }, error => {
      console.log(error);
    })
  }

  logout() {
    this.accountService.logout();
    
  }

 
}
