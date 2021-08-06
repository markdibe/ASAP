import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from 'src/app/_modules/person';
import { PersonService } from 'src/app/_services/person.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-person-detail',
  templateUrl: './person-detail.component.html',
  styleUrls: ['./person-detail.component.css']
})
export class PersonDetailComponent implements OnInit {
  @Input() person: Person;
  baseImageUrl: string = environment.baseImageUrl;

  constructor(private personService: PersonService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getPerson();
  }

  getPerson() {
    const personId: number = Number(this.route.snapshot.paramMap.get('id'));
    console.log(personId);
    if (!isNaN(personId)) {

      this.personService.getPerson(personId).subscribe((person: Person) => {
        this.person = person;
      }, (error) => {
        console.log(error);
      })
    }
  }


}
