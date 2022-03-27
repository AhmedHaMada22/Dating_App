import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Member } from '../_model/member';

@Component({
  selector: 'app-members_card',
  templateUrl: './members_card.component.html',
  styleUrls: ['./members_card.component.css'],
})
export class MemberCardsComponent implements OnInit {
  @Input() member: Member;
  constructor() { }

  ngOnInit(): void {
   
  }

 

}
