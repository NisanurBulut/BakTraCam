import { Component, OnInit, ViewChild, ElementRef, OnDestroy, AfterViewInit, DebugElement } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Subject } from 'rxjs';
import { takeUntil, tap, map, mergeMap } from 'rxjs/operators';

import { MatDialog } from '@angular/material/dialog';
import { DuyuruModel, EnumCategory, Unvan } from 'app/models';
import { DuyuruService } from '../duyuru.service';
import { DuyuruFormPopupComponent } from '../popup/duyuru-form-popup.component';
import { SnackbarService } from 'app/shared/snackbar.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-duyuru-list',
  templateUrl: './duyuru-list.component.html',
  styleUrls: ['./duyuru-list.component.scss']
})
export class DuyuruListComponent implements OnInit, OnDestroy, AfterViewInit {
  loading: boolean;
  duyuruListe: DuyuruModel[];

  displayedColumns: string[] = ['Id', 'Aciklama', 'Tarihi', 'Actions'];
  dataSource: MatTableDataSource<DuyuruModel>;

  Unvan = Unvan;
  EnumCategory = EnumCategory;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('filter', { static: true })
  filter: ElementRef;

  private _kullaniciSilAction = new Subject<number>();
  private _unsubscribeAll: Subject<any> = new Subject();

  constructor(private _dService: DuyuruService,
    private _dialog: MatDialog,
    private _translate: TranslateService,
    private _snackbarService: SnackbarService) { }

  ngOnInit() {
    this.duyuruListesiniGetir();
    this._kullaniciSilAction.pipe(
      takeUntil(this._unsubscribeAll),
      mergeMap((duyuruId) => this._dService.silDuyuru(duyuruId)),
      tap((res) => {
        const msg = this._translate.instant('Duyuru silindi.');
        this._snackbarService.show(msg);
        this.duyuruListesiniGetir();
      })
    ).subscribe();
  }
  ngAfterViewInit() { }
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
  deleteDuyuru(duyuruId: number) {
    this._kullaniciSilAction.next(duyuruId);
  }
  private duyuruListesiniGetir() {
    this._dService.getirDuyuruListesi().pipe(
      takeUntil(this._unsubscribeAll),
      tap(() => this.loading = true),
      map((resListe) => {
        this.duyuruListe = (resListe as DuyuruModel[]);
        this.dataSource = new MatTableDataSource(this.duyuruListe);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }),
      tap(() => this.loading = false),
    ).subscribe()
  }
  createNewDuyuru(): void {
    this.openDuyuruPopup({ id: 0 });
  }
  editDuyuru(kullaniciId: any): void {
    this.openDuyuruPopup({ id: kullaniciId });
  }
  openDuyuruPopup(data: any): void {
    this._dialog.open(DuyuruFormPopupComponent, {
      disableClose: true,
      panelClass: 'form-dialog',
      data: data
    }).afterClosed().pipe(
      takeUntil(this._unsubscribeAll)
    ).subscribe((res) => {
      this.duyuruListesiniGetir();
    });
  }
}
