import { Country } from '@angular-material-extensions/select-country';
import { Component, Input, OnInit, Self } from '@angular/core';
import { ControlValueAccessor, FormGroup, NgControl } from '@angular/forms';

@Component({
  selector: 'app-country-input',
  templateUrl: './country-input.component.html',
  styleUrls: ['./country-input.component.css']
})
export class CountryInputComponent implements ControlValueAccessor {
  title = 'select-country';
  @Input() label:string;
  @Input() type: 'text';
  
  constructor(@Self() public ngControl: NgControl) { 
    this.ngControl.valueAccessor=this;
  }
  writeValue(obj: any): void {
  }
  registerOnChange(fn: any): void {
  }
  registerOnTouched(fn: any): void {
  }
  onCountrySelected($event: Country) {
    console.log($event);
  }
}
