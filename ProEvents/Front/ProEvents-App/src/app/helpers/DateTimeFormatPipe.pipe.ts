import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { Contants } from '../constants/constants';

@Pipe({
  name: 'DateTimeFormat',
})
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {
  transform(value: any, args?: any): any {
    return super.transform(value, Contants.DATE_TIME_FORMAT);
  }
}
