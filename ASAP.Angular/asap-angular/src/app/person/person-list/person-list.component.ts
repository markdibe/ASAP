import { Component, OnInit } from '@angular/core';
import { BaseFilter } from 'src/app/_modules/baseFilter';
import { Person } from 'src/app/_modules/person';
import { PersonService } from 'src/app/_services/person.service';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {

  people: Person[];
  baseFilter: BaseFilter = {orderByDescending :false, orderProperty:'',pageNumber:0,properties:[],range:100,values:[] };
  constructor(private personService: PersonService) { 
    
  }

  ngOnInit(): void {

    this.getPeople();
  }

  getPeople() {
    
    this.personService.getPeople(this.baseFilter).subscribe((people: Person[]) => {
      this.people = people;
      console.log(this.people);
    }, (error) => {
      console.log(error);
    });
  }

}
