import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { Event } from 'src/app/models/Event';
import { EventService } from 'src/app/services/event.service';
import { NotificationService } from 'src/app/services/notification.service';

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
    private notificationService: NotificationService,
    private spinner: NgxSpinnerService
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
    this.spinner.show();
    this.eventService.getEvents().subscribe({
      next: (events: Event[]) => {
        this._events = events;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.notificationService.showError(
          'Não foi possível carregar os eventos. Tente novamente mais tarde.'
        );
        console.log(error);
      },
      complete: () => this.spinner.hide(),
    });
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
