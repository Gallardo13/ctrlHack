import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MapModule } from './maps/maps.module';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { AppService } from './app.service';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    MapModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    AppService,
    HttpClient
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
