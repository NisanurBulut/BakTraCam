import { Component, OnInit, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Subject } from 'rxjs';
import { takeUntil, tap, map } from 'rxjs/operators';
import { KullaniciService } from './kullanici.service';
import { MatDialog } from '@angular/material/dialog';
import { KullaniciFormPopupComponent } from './popups/kullanici-form-popup/kullanici-form-popup.component';
import { KullaniciModel } from 'app/models/kullanici.model';

@Component({
  selector: 'app-kullanici',
  templateUrl: './kullanici.component.html',
  styleUrls: ['./kullanici.component.scss']
})
export class KullaniciComponent implements OnInit, OnDestroy {
  loading: boolean;
  bakimListe: KullaniciModel[];

  displayedColumns: string[] = ['id', 'ad', 'unvan', 'actions'];
  dataSource: MatTableDataSource<KullaniciModel>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('filter', { static: true })
  filter: ElementRef;

  private _unsubscribeAll: Subject<any> = new Subject();
  constructor(private _kService: KullaniciService, private _dialog: MatDialog) { }

  ngOnInit() {
  }
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

  private kullaniciListesiniGetir() {
    this._kService.getirKullaniciListesi().pipe(
      takeUntil(this._unsubscribeAll),
      tap(() => this.loading = true),
      map((resListe) => {
        this.bakimListe = (resListe as KullaniciModel[]);
        console.log(this.bakimListe);
        this.dataSource = new MatTableDataSource(this.bakimListe);
        console.log(this.dataSource.data);
      }),
      tap(() => this.loading = false),
    ).subscribe()
  }
  createNewTask(): void {
    this.openKullaniciPopup({ id: 0 });
  }
  openKullaniciPopup(data: any): void {
    this._dialog.open(KullaniciFormPopupComponent, {
      disableClose: true,
      panelClass: 'form-dialog',
      data: data
    }).afterClosed().pipe(
      takeUntil(this._unsubscribeAll)
    ).subscribe((res) => {
      if (res) {
        this.kullaniciListesiniGetir();
      }
    });
  }
}
