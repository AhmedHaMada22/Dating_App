import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from 'oidc-client';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Member } from '../_model/member';


const httpOptions = { headers: new HttpHeaders({ Authorization: 'Bearer' + JSON.parse(localStorage.getItem('user')).token }) }
@Injectable({
  providedIn: 'root'
})

export class MembersService {
  Member: any;
  url: string = 'https://localhost:44326/api/users';
  constructor(private http: HttpClient) { }

  getMembers() {
    this.http.get(this.url).subscribe(Member => this.Member = Member);
  }

  getMember(username : string) {
    return this.http.get<Member>(this.url + 'users/' + username, httpOptions );
  }
 
}

