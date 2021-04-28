import { Routes } from '@angular/router';
import { UserProfileComponent } from '../../user-profile/user-profile.component';
import { HomeComponent } from 'app/home/home.component';
import { KullaniciListComponent } from 'app/kullanici/list/kullanici-list.component';
import { BakimListComponent, BakimTamamlananListComponent } from 'app/bakim';
import { DuyuruListComponent } from 'app/duyuru/list/duyuru-list.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'home',           component: HomeComponent },
    { path: 'bakim',          component: BakimListComponent },
    { path: 'tamamlananbakim', component: BakimTamamlananListComponent },
    { path: 'kullanici',      component: KullaniciListComponent },
    { path: 'duyuru',         component: DuyuruListComponent },
];
