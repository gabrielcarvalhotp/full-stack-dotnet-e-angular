import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventService } from '../services/event.service';
import { Event } from '../models/Event';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NotificationService } from '../services/notification.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  private _events: Event[] = [];
  public widthImg = 150;
  public marginImg = 2;
  public showImage = true;
  private _searchText = '';
  public modalRef: BsModalRef;

  constructor(
    private eventService: EventService,
    private modalService: BsModalService,
    private notificationService: NotificationService
  ) {}

  public get events(): Event[] {
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

  ngOnInit(): void {
    this.getEvents();
  }

  private getEvents(): void {
    this.eventService.getEvents().subscribe(
      (response) => (this._events = response as any[]),
      (error) => console.log(error)
    );
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.notificationService.showSuccess('Evento excluido com sucesso!');
    this.modalRef.hide();
  }

  decline(): void {
    this.modalRef.hide();
  }
}
