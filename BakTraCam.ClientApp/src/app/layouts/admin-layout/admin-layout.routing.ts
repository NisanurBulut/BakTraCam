import { Routes } from '@angular/router';
import { UserProfileComponent } from '../../user-profile/user-profile.component';
import { HomeComponent } from 'app/home/home.component';
import { KullaniciListComponent } from 'app/kullanici/list/kullanici-list.component';
import { BakimListComponent, BakimTamamlananListComponent } from 'app/bakim';

export const AdminLayoutRoutes: Routes = [
    // {
    //   path: '',
    //   children: [ {
    //     path: 'dashboard',
    //     component: DashboardComponent
    // }]}, {
    // path: '',
    // children: [ {
    //   path: 'userprofile',
    //   component: UserProfileComponent
    // }]
    // }, {
    //     path: '',
    //     children: [ {
    //         path: 'notifications',
    //         component: NotificationsComponent
    //     }]
    // }, {
    //     path: '',
    //     children: [ {
    //         path: 'typography',
    //         component: TypographyComponent
    //     }]
    // }, {
    //     path: '',
    //     children: [ {
    //         path: 'upgrade',
    //         component: UpgradeComponent
    //     }]
    // }
    { path: 'home',           component: HomeComponent },
    { path: 'bakim',          component: BakimListComponent },
    { path: 'tamamlananbakim', component: BakimTamamlananListComponent },
    { path: 'kullanici',      component: KullaniciListComponent },
    { path: 'user-profile',   component: UserProfileComponent },
];
