import { Input, ViewEncapsulation } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/_modules/person';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-person-card',
  templateUrl: './person-card.component.html',
  styleUrls: ['./person-card.component.css'],
  encapsulation:ViewEncapsulation.Emulated
})
export class PersonCardComponent implements OnInit {
  baseImageUrl:string = environment.baseImageUrl;
@Input() person:Person;

  constructor() { }

  ngOnInit(): void {
  }

}
