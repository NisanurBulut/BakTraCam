import { Component, OnInit, ViewChild, ElementRef, OnDestroy, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Subject } from 'rxjs';
import { takeUntil, tap, map, mergeMap } from 'rxjs/operators';
import { KullaniciService } from '../kullanici.service';
import { MatDialog } from '@angular/material/dialog';
import { KullaniciModel } from 'app/models/kullanici.model';
import { EnumCategory, Unvan } from 'app/models';
import { KullaniciFormPopupComponent } from '../popups/kullanici-form-popup/kullanici-form-popup.component';

@Component({
  selector: 'app-kullanici-list',
  templateUrl: './kullanici-list.component.html',
  styleUrls: ['./kullanici-list.component.scss']
})
export class KullaniciListComponent implements OnInit, OnDestroy, AfterViewInit {
  loading: boolean;
  kullaniciListe: KullaniciModel[];

  displayedColumns: string[] = ['Id', 'Ad', 'UnvanId', 'Actions'];
  dataSource: MatTableDataSource<KullaniciModel>;

  Unvan = Unvan;
  EnumCategory = EnumCategory;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('filter', { static: true })
  filter: ElementRef;

  private _kullaniciSilAction = new Subject<number>();
  private _unsubscribeAll: Subject<any> = new Subject();

  constructor(private _kService: KullaniciService, private _dialog: MatDialog) { }

  ngOnInit() {
    this.kullaniciListesiniGetir();
    this._kullaniciSilAction.pipe(
      takeUntil(this._unsubscribeAll),
      mergeMap((bakimId) => this._kService.silKullanici(bakimId)),
      tap((res) => {
        console.log(res);
        this.kullaniciListesiniGetir();
      })
    ).subscribe();
  }
  ngAfterViewInit() {}
  ngOnDestroy(): void {
    this._unsubscribeAll.unsubscribe();
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  deleteKullanici(kullaniciId: number) {
    this._kullaniciSilAction.next(kullaniciId);
  }
  private kullaniciListesiniGetir() {
    this._kService.getirKullaniciListesi().pipe(
      takeUntil(this._unsubscribeAll),
      tap(() => this.loading = true),
      map((resListe) => {
        this.kullaniciListe = (resListe as KullaniciModel[]);
        this.dataSource = new MatTableDataSource(this.kullaniciListe);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }),
      tap(() => this.loading = false),
    ).subscribe()
  }
  createNewKullanici(): void {
    this.openKullaniciPopup({ id: 0 });
  }
  editKullanici(kullaniciId: any): void {
    this.openKullaniciPopup({ id: kullaniciId });
  }
  openKullaniciPopup(data: any): void {
    this._dialog.open(KullaniciFormPopupComponent, {
      disableClose: true,
      panelClass: 'form-dialog',
      data: data
    }).afterClosed().pipe(
      takeUntil(this._unsubscribeAll)
    ).subscribe((res) => {
      this.kullaniciListesiniGetir();
    });
  }
}
