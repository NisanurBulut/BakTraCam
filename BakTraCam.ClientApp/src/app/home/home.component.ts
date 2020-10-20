import { Component, OnInit } from '@angular/core';
import { BakimService } from 'app/bakim';
import { BakimDurum, BakimModelBasic, BakimTip } from 'app/models';
import { Observable, Subject } from 'rxjs';
import 'rxjs/add/observable/interval';
import { map, takeUntil, tap } from 'rxjs/operators';
import { trigger, transition, style, animate, query, stagger } from '@angular/animations';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  animations: [
    trigger('listAnimation', [
      transition('* => *', [ // each time the binding value changes
        query(':leave', [
          stagger(250, [
            animate('0.8s', style({ opacity: 0 }))
          ])
        ], { optional: true }),
        query(':enter', [
          style({ opacity: 0 }),
          stagger(250, [
            animate('0.8s', style({ opacity: 1 }))
          ])
        ], { optional: true })
      ])
    ])
  ],
})
export class HomeComponent implements OnInit {
  loading: boolean;
  bakimListe: BakimModelBasic[];
  BakimTip = BakimTip;
  bakimDurum = BakimDurum;
  private _unsubscribeAll: Subject<any> = new Subject();
  constructor(private _bService: BakimService) {
    this.bakimListeGetir();
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
