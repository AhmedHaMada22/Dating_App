import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_Services/Account.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent implements OnInit {
  //pass data from register component to home
 // @Input() usersFromHomeComponent: any;
  //-------------------------------------
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  register() {
    this.accountService.register(this.model).subscribe(response => { console.log(response); this.cancel(); },
      error => { console.log(error); })
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
