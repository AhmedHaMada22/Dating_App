import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MembersService } from '../_Services/members.service';



@Component({
  selector: 'app-members',
  templateUrl: './members.component.html'
})
export class MembersComponent implements OnInit {
  Member: any;
  url: string = 'https://localhost:44326/api/users';

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
   this.http.get(this.url).subscribe(Member => this.Member = Member);
  }

}
