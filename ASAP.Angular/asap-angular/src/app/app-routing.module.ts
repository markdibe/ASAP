import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonDetailComponent } from './person/person-detail/person-detail.component';
import { PersonListComponent } from './person/person-list/person-list.component';

const routes: Routes = [
  { path: 'people', component: PersonListComponent },
  { path: 'person/:id', component: PersonDetailComponent }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
