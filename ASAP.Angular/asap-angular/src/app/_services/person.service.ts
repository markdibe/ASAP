import { HttpClient, HttpHeaderResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../_modules/person';
import { environment } from 'src/environments/environment';
import { BaseFilter } from '../_modules/baseFilter';
@Injectable({
  providedIn: 'root'
})
export class PersonService {
  person: Person | undefined;
  baseUrl: string = environment.baseURl;

  constructor(private http: HttpClient) {

  }

  getPerson(id: number) {
    return this.http.get<Person>(this.baseUrl + 'people/get/' + id);
  }

  getPeople(baseFilter: BaseFilter) {
    return this.http.get<Person[]>(this.baseUrl + 'people/get-all?' + `pageNumber=${baseFilter.pageNumber}&range=${baseFilter.range}&orderProperty=${baseFilter.orderProperty}&orderByDescending=${baseFilter.orderByDescending}`)
  }

  addPerson(person: Person) {
    return this.http.post<Person>(this.baseUrl + 'people/add', person);
  }

  updatePerson(person: FormData) {
    let headers = new HttpHeaders();
    headers.append('content-type', 'multipart/form-data');
    headers.append('accept', 'application/json');
    const httpOptions = {
      headers: headers
    };
    return this.http.put<Person>(this.baseUrl + 'people/update/'+person.get('id'), person, httpOptions);
  }


}
