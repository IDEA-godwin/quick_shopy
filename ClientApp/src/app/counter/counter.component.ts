import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {

  currentCount = 0;
  errMsg: string = "";

  count(num: number) {

    if (this.currentCount == 0 && num == -1){
      this.errMsg = "counter can not go below 0";
      return;
    }

    if (this.currentCount == 9 && num == 1){
      this.currentCount = 0;
      return;
    }
    this.errMsg = "";
    this.currentCount += num;
  }

  incrementCounter() {
    this.count(1);
  }

  decrementCounter() {
    this.count(-1)
  }

}
