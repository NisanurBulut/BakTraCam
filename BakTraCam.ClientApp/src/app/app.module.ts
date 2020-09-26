import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';


import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';

import { AppComponent } from './app.component';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { MaterialModule } from './shared/material.module';
import { BaseCommonModule } from './shared/baseCommon.module';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { SnackbarService } from './shared/snackbar.service';
import { FuseTranslationLoaderService } from './shared/translation-loader.service';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    MatSnackBarModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
    MaterialModule,
    BaseCommonModule,
    TranslateModule.forRoot()
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,

  ],
  providers: [
    SnackbarService,
    FuseTranslationLoaderService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
