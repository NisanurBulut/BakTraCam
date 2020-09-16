import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';

@Component({
    selector: 'app-bakim-detail-form',
    templateUrl: './bakim-detail-form.component.html',
    styleUrls: ['./bakim-detail-form.component.scss']
})
export class BakimDetailFormComponent implements OnInit, AfterViewInit, OnDestroy {
    constructor() {
        // bakım bilgisini getirmeli ve göstermeli
     }
    ngOnDestroy(): void {
        throw new Error('Method not implemented.');
    }
    ngAfterViewInit(): void {
        throw new Error('Method not implemented.');
    }
    ngOnInit(): void {
        throw new Error('Method not implemented.');
    }
}
