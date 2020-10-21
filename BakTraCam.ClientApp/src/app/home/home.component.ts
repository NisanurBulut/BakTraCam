import { Component, Inject, OnInit } from '@angular/core';
import { BakimService } from 'app/bakim';
import { BakimDurum, BakimModelBasic, BakimTip, DuyuruModel } from 'app/models';
import { Observable, Subject } from 'rxjs';
import 'rxjs/add/observable/interval';
import { map, takeUntil, tap } from 'rxjs/operators';
import { DuyuruService } from 'app/duyuru/duyuru.service';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  loading: boolean;
  bakimListe: BakimModelBasic[];
  duyuruListe: DuyuruModel[];
  BakimTip = BakimTip;
  bakimDurum = BakimDurum;
  private _unsubscribeAll: Subject<any> = new Subject();
  constructor(private _bService: BakimService, private _dService: DuyuruService, @Inject(DOCUMENT) private document: Document) {
    setTimeout(function() {  this.document.location.reload(); }, 30000);
    this.bakimListeGetir();
    this.duyuruListesiniGetir();
  }
  private duyuruListesiniGetir() {
    this._dService.getirDuyuruListesi().pipe(
      takeUntil(this._unsubscribeAll),
      tap(() => this.loading = true),
      map((resListe) => {
        this.duyuruListe = (resListe as DuyuruModel[]);
      }),
      tap(() => this.loading = false),
    ).subscribe()
  }
  bakimListeGetir(): void {
    this.bakimListe = [];
    this._bService.getirOnBesGunYaklasanBakimListesi().pipe(
      takeUntil(this._unsubscribeAll),
      tap(() => this.loading = true),
      map((resListe) => {
        this.bakimListe = (resListe as BakimModelBasic[]);
        console.log(this.bakimListe);
      }),
      tap(() => this.loading = false),
    ).subscribe();
  }
  ngOnInit() {
    // Observable.interval(3000)
    //   .pipe(takeUntil(this._unsubscribeAll))
    //   .subscribe((val) => { this.bakimListeGetir(); });
  }
}
