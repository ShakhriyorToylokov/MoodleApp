import { Component, Input, OnInit } from '@angular/core';
import { Student } from 'src/app/_models/student';

@Component({
  selector: 'app-studentphoto-editor',
  templateUrl: './studentphoto-editor.component.html',
  styleUrls: ['./studentphoto-editor.component.css']
})
export class StudentphotoEditorComponent implements OnInit {
  @Input() student:Student;
  constructor() { }
  ngOnInit(): void {
  }

}
