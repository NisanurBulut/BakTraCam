import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'enumkeys' })
export class EnumKeysPipe implements PipeTransform {
    transform(value: any[]): any[] {
        const keys = [];
        for (const enumMember in value) {
            if (parseInt(enumMember, 10) >= 0) {
                keys.push({ key: enumMember, value: value[enumMember] });
            }
        }
        return keys;
    }
}
