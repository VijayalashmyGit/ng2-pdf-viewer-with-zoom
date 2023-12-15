import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { HomeComponent } from './home/home.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { PageTemplateComponent } from './page-template/page-template.component';

import { PdfViewerModule } from 'ng2-pdf-viewer';
import { ZoomPdfComponent } from './page-template/zoom-pdf/zoom-pdf.component';
import { MatDialogModule } from '@angular/material/dialog';
import { HotspotComponent } from './page-template/hotspot/hotspot.component';
import { PdfViewerComponent } from './page-template/pdf-viewer/pdf-viewer.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PageTemplateComponent,
    PdfViewerComponent,
    ZoomPdfComponent,
    HotspotComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatButtonModule,
    MatCardModule,
    MatProgressSpinnerModule,
    PdfViewerModule,
    MatDialogModule,
    MatIconModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'chapter/:id', component: PageTemplateComponent },
    ]),
    BrowserAnimationsModule
  ],

  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
