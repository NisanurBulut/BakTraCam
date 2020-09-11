import { NativeDateAdapter } from '@angular/material/core';
import * as moment from 'moment';
import { FormControl } from '@angular/forms';


export const CUSTOM_DATE_FORMATS = {
    parse: {
        dateInput: { month: 'short', year: 'numeric', day: 'numeric' }
    },
    display: {
        dateInput: 'YYYY-MM-DD',
        monthYearLabel: { year: 'numeric', month: 'short' },
        dateA11yLabel: { year: 'numeric', month: 'long', day: 'numeric' },
        monthYearA11yLabel: { year: 'numeric', month: 'long' },
    }
};
export class CustomDateAdapter extends NativeDateAdapter {
    format(date: Date, displayFormat: Object): string {
        moment.locale('tr-TR'); // Choose the locale
        const formatString: string = (displayFormat === 'input') ? 'yyyy-MM-dd' : 'LLL';
        return moment(date).format(formatString);
    }
}

export class DateValidator {

    static ptDate(control: FormControl): { [key: string]: any } {
        // tslint:disable-next-line:max-line-length
        const ptDatePattern = /^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$/g;

        if (!control.value.match(ptDatePattern)) {
            return { 'ptDate': true };
        }

        return null;
    }

    static usDate(control: FormControl): { [key: string]: any } {
        // tslint:disable-next-line:max-line-length
        const usDatePattern = /^02\/(?:[01]\d|2\d)\/(?:19|20)(?:0[048]|[13579][26]|[2468][048])|(?:0[13578]|10|12)\/(?:[0-2]\d|3[01])\/(?:19|20)\d{2}|(?:0[469]|11)\/(?:[0-2]\d|30)\/(?:19|20)\d{2}|02\/(?:[0-1]\d|2[0-8])\/(?:19|20)\d{2}$/;

        if (!control.value.match(usDatePattern)) {
            return { 'usDate': true };
        }

        return null;
    }
}
