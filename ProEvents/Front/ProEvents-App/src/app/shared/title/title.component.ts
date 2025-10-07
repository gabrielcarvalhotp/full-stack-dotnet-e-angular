import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss'],
})
export class TitleComponent implements OnInit {
  @Input() title: string;
  @Input() routerGroup: string;
  @Input() subtitle = 'Desde 2021';
  @Input() iconClass = 'fa fa-user';
  @Input() buttonSearchVisible = true;

  constructor(private router: Router) {}

  ngOnInit() {}

  public list() {
    this.router.navigate([`/${this.routerGroup.toLocaleLowerCase()}/list`]);
  }
}
