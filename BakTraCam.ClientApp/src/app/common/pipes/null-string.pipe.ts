
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'nullstring' })
export class NullStringPipe implements PipeTransform {
    transform(value: any): string {
        if (typeof value === 'undefined' || value === null || value === '') { return '-'; } else { return value; }
    }
}
