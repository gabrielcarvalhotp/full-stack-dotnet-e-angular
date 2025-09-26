import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Event } from '../models/Event';
import { Observable } from 'rxjs';

@Injectable()
export class EventService {
  private baseUrl = 'https://localhost:5001/api/events';

  constructor(private http: HttpClient) {}

  getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(this.baseUrl);
  }

  getEventById(id: number): Observable<Event> {
    return this.http.get<Event>(`${this.baseUrl}/${id}`);
  }
}
