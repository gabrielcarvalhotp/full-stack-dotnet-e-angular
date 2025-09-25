import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  BASE_URL = 'https://localhost:5001/api/events';

  constructor(private http: HttpClient) {}

  getEvents() {
    return this.http.get(this.BASE_URL);
  }
}
