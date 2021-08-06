import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonCreateComponent } from './person/person-create/person-create.component';
import {HttpClientModule} from '@angular/common/http';
import { PersonListComponent } from './person/person-list/person-list.component';
import { NavComponent } from './nav/nav.component';
import { PersonDetailComponent } from './person/person-detail/person-detail.component';
import { PersonCardComponent } from './person/person-card/person-card.component';
import { AddressInfoComponent } from './address/address-info/address-info.component';
import { PersonEditComponent } from './person/person-edit/person-edit.component';
import { LocalDateValueAccessorModule } from 'angular-date-value-accessor';


@NgModule({
  declarations: [
    AppComponent,
    PersonCreateComponent,
    PersonListComponent,
    NavComponent,
    PersonDetailComponent,
    PersonCardComponent,
    AddressInfoComponent,
    PersonEditComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    LocalDateValueAccessorModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
