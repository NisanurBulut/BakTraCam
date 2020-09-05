import { Component, OnInit, OnDestroy } from '@angular/core';
import { BakimService } from './bakim.service';
import { BakimModel } from 'app/models';
import { Subject } from 'rxjs';
import { takeUntil, tap, map } from 'rxjs/operators';

@Component({
  selector: 'app-bakim',
  templateUrl: './bakim.component.html',
  styleUrls: ['./bakim.component.scss']
})
export class BakimComponent implements OnInit, OnDestroy {
  loading: boolean;
  bakimListe: BakimModel[];
  private _unsubscribeAll: Subject<any> = new Subject();

  constructor(private _bService: BakimService) { }
  ngOnInit() {
    this.bakimListesiniGetir();
  }
  ngOnDestroy() {
    this._unsubscribeAll.unsubscribe();
  }
  private bakimListesiniGetir() {
    this._bService.getirBakimListesi().pipe(
      takeUntil(this._unsubscribeAll),
      tap(() => this.loading = true),
      map((bakimListe) => {
        this.bakimListe = bakimListe;
        console.log(bakimListe);
      }),
      tap(() => this.loading = false),
    ).subscribe();
  }
}
