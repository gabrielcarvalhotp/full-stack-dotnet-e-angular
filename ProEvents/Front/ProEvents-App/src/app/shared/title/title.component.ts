import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss'],
})
export class TitleComponent implements OnInit {
  @Input() title: string;
  @Input() subtitle = 'Desde 2021';
  @Input() iconClass = 'fa fa-user';
  @Input() buttonSearchVisible = true;

  ngOnInit() {}
}
