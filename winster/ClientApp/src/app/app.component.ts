import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  categoryList: any = ['NEWTOWN','SYDNEY','GENERAL'];
  title = 'app';
  public searchword: string;
  constructor() {
    this.searchword ="NEWTOWN";
  }
  OnCategoryCahnge(e) {
    this.searchword = e.target.value;
  }
}
