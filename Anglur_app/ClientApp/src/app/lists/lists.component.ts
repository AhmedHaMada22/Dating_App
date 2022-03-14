import { Component } from '@angular/core';

@Component({
  selector: 'app-lists-component',
  templateUrl: './lists.component.html'
})
export class ListsComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
