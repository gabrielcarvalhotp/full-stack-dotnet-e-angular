import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class NotificationService {
  constructor(private toastr: ToastrService) {}

  showSuccess(message: string): void {
    this.toastr.success(message, 'Successo!');
  }

  showError(message: string): void {
    this.toastr.error(message, 'Erro!');
  }

  showInfo(message: string): void {
    this.toastr.info(message, 'Informação!');
  }

  showWarning(message: string): void {
    this.toastr.warning(message, 'Atenção!');
  }

  showCustom(message: string, title: string): void {
    this.toastr.show(message, title);
  }
}
