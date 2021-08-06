import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Person } from 'src/app/_modules/person';
import { PersonService } from 'src/app/_services/person.service';

@Component({
  selector: 'app-person-edit',
  templateUrl: './person-edit.component.html',
  styleUrls: ['./person-edit.component.css']
})
export class PersonEditComponent implements OnInit {

  @Input() person: Person;
  editPersonForm: FormGroup;
  file: File;
  constructor(private personService: PersonService) { }

  ngOnInit(): void {
    this.init();
  }

  init() {
    this.editPersonForm = new FormGroup({
      firstName: new FormControl(this.person.firstName, [Validators.required, Validators.maxLength(200), Validators.minLength(4)]),
      lastName: new FormControl(this.person.lastName, [Validators.required, Validators.maxLength(200), Validators.minLength(4)]),
      dateOfBirth: new FormControl(new Date(this.person.dateOfBirth), [Validators.required]),
      biography: new FormControl(this.person.biography, Validators.maxLength(2000)),
      file: new FormControl('')
    });
  }

  update() {
    const formData = new FormData();
    let editFormData = this.editPersonForm.value;
    let keys = Object.keys(editFormData);
    keys.forEach((key) => {
      formData.append(key, editFormData[key]);
    });
    formData.set('file', this.file);
    formData.append('id', this.person.id.toString());
    this.personService.updatePerson(formData).subscribe((person: Person) => {
      this.person = person;
    }, (error) => {
      console.log(error);
    });

  }

  onFileChange(event: any) {
    this.file = event.target.files[0];
  }


}
