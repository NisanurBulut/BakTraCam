import { FormGroup, FormControl, FormArray } from '@angular/forms';

export function deepCopy(obj): any {
    let copy;

    // Handle the 3 simple types, and null or undefined
    if (null == obj || 'object' !== typeof obj) return obj;

    // Handle Date
    if (obj instanceof Date) {
        copy = new Date();
        copy.setTime(obj.getTime());
        return copy;
    }

    // Handle Array
    if (obj instanceof Array) {
        copy = [];
        for (let i = 0, len = obj.length; i < len; i++) {
            copy[i] = deepCopy(obj[i]);
        }
        return copy;
    }

    // Handle Object
    if (obj instanceof Object) {
        copy = {};
        for (const attr in obj) {
            if (obj.hasOwnProperty(attr)) copy[attr] = deepCopy(obj[attr]);
        }
        return copy;
    }

    throw new Error('Unable to copy obj! Its type isn\'t supported.');
}

export const markAsTouched = (group: FormGroup | FormArray) => {
    group.markAsTouched();
    for (const i in group.controls) {
        if (group.controls[i] instanceof FormControl) {
            group.controls[i].markAsTouched();
        } else {
            markAsTouched(group.controls[i]);
        }
    }
};

export const markAsUntouched = (group: FormGroup | FormArray) => {
    group.markAsUntouched({ onlySelf: true });

    Object.keys(group.controls).map((field) => {
        const control = group.get(field);
        if (control instanceof FormControl) {
            control.markAsUntouched({ onlySelf: true });

        } else if (control instanceof FormGroup) {
            this.markAsUntouched(control);
        }
    });
};

export function compareEnumKeys(v1: any, v2: any): boolean {
    return v1 && v2 && v1.toString() === v2.toString();
}