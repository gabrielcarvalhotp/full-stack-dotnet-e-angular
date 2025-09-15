import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  private _events: any[] = [];
  public widthImg = 150;
  public marginImg = 2;
  public showImage = true;
  private _searchText = '';

  public get events(): any[] {
    return this._events.filter(
      (event) =>
        event.theme.toLowerCase().includes(this._searchText.toLowerCase()) ||
        event.location.toLowerCase().includes(this._searchText.toLowerCase())
    );
  }

  public get searchText(): string {
    return this._searchText;
  }

  public set searchText(value: string) {
    this._searchText = value;
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEvents();
  }

  private getEvents() {
    this.http.get('https://localhost:5001/api/events').subscribe(
      (response) => (this._events = response as any[]),
      (error) => console.log(error)
    );
  }
}
