import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Address } from 'src/app/_modules/address';

@Component({
  selector: 'app-address-info',
  templateUrl: './address-info.component.html',
  styleUrls: ['./address-info.component.css']
})
export class AddressInfoComponent implements OnInit {

  @Input() address:Address;
  

  constructor() {
  
  }

  ngOnInit(): void {
    console.log(this.address);
  }

  

}
