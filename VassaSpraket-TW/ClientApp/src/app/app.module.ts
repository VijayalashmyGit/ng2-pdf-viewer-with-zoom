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
import { PagetemplateComponent } from './pagetemplate/pagetemplate.component';

import { PdfViewerModule } from 'ng2-pdf-viewer';
import { ZoompdfComponent } from './pagetemplate/zoompdf/zoompdf.component';
import { MatDialogModule } from '@angular/material/dialog';
import { HotspotComponent } from './pagetemplate/hotspot/hotspot.component';
import { PdfviewerComponent } from './pagetemplate/pdfviewer/pdfviewer.component';

@NgModule({
  declarations: [
    AppComponent,   
    HomeComponent,
    PagetemplateComponent,
    PdfviewerComponent,
    ZoompdfComponent,
    HotspotComponent
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatButtonModule,
    MatCardModule,
    PdfViewerModule,
    MatDialogModule,
    MatIconModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'chapter/:id', component: PagetemplateComponent },
    
    ], { bindToComponentInputs: true }),
    BrowserAnimationsModule
  ],
  
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
