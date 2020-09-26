import { Pipe, PipeTransform } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { EnumCategory } from 'app/models/enums';


@Pipe({ name: 'enumtranslate' })
export class EnumTranslatePipe implements PipeTransform {
    constructor(private _translate: TranslateService) { }

    transform(value: string, translateCategory: EnumCategory): string {

        if (!value) {
            return '';
        } else if (!translateCategory) {
            return value;
        }

        let result = this._translate.instant('ENUMS.' + EnumCategory[translateCategory] + '.' + value);

        if (result.startsWith('ENUMS.')) {
            result = value;
        }

        return result;
    }
}
