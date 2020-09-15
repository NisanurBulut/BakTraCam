import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { snackbarConfig } from './app-config';

@Injectable()
export class SnackbarService {
    constructor(private _snackBar: MatSnackBar) {

    }
    show(message: string): void {
        this._snackBar.open(message, '', snackbarConfig);
    }
}
