import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  public events: any[] = [];
  public widthImg = 50;
  public marginImg = 2;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEvents();
  }

  private getEvents() {
    this.http.get('https://localhost:5001/api/events').subscribe(
      (response) => (this.events = response as any[]),
      (error) => console.log(error)
    );
  }
}
